namespace Catalog.API.Application.Services;

public class TypeService : ITypeService
{
    private readonly ITypeRepository _typeRepository;
    private readonly IMapper _mapper;

    public TypeService(
        ITypeRepository typeRepository,
        IMapper mapper)
    {
        _typeRepository = typeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TypeModel>> Get(int page, int size)
    {
        var entities = await _typeRepository.Get(page, size);

        var models = _mapper.Map<IEnumerable<TypeModel>>(entities);

        return models;
    }

    public async Task<TypeModel> GetById(int id)
    {
        var entity = await _typeRepository.GetById(id);

        var model = _mapper.Map<TypeModel>(entity);

        return model;
    }

    public async Task<int> Add(TypeModel model)
    {
        var entity = _mapper.Map<TypeEntity>(model);
        return await _typeRepository.Add(entity);
    }

    public async Task<int> Update(int id, TypeModel model)
    {
        var entity = await _typeRepository.GetById(id);
        entity.Title = model.Title;
        return await _typeRepository.Update(entity);
    }

    public async Task<int> Delete(int id)
    {
        return await _typeRepository.Delete(id);
    }
}
