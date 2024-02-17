namespace Catalog.API.Application.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public BrandService(
        IBrandRepository brandRepository,
        IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BrandModel>> Get(int page, int size)
    {
        var entities = await _brandRepository.Get(page, size);

        var models = _mapper.Map<IEnumerable<BrandModel>>(entities);

        return models;
    }

    public async Task<BrandModel> GetById(int id)
    {
        var entity = await _brandRepository.GetById(id);

        var model = _mapper.Map<BrandModel>(entity);

        return model;
    }

    public async Task<int> Add(BrandModel model)
    {
        var entity = _mapper.Map<BrandEntity>(model);
        return await _brandRepository.Add(entity);
    }

    public async Task<int> Update(int id, BrandModel model)
    {
        var entity = await _brandRepository.GetById(id);
        entity.Title = model.Title;
        return await _brandRepository.Update(entity);
    }

    public async Task<int> Delete(int id)
    {
        return await _brandRepository.Delete(id);
    }
}

