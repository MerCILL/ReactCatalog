using Catalog.API.DataAccess.Entities;

namespace Catalog.API.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IBrandService _brandService;
    private readonly ITypeService _typeService;

    public ProductService(
        IProductRepository productRepository,
        IMapper mapper,
        IBrandService brandService,
        ITypeService typeService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _brandService = brandService;
        _typeService = typeService;
    }

    public async Task<IEnumerable<ProductModel>> Get(int page, int size)
    {
        var entites = await _productRepository.Get(page, size);

        var models = _mapper.Map<IEnumerable<ProductModel>>(entites);

        return models;
    }

    public async Task<ProductModel> GetById(int id)
    {
        var entity = await _productRepository.GetById(id);

        var model = _mapper.Map<ProductModel>(entity);

        return model;
    }

    public async Task<int> Add(ProductModel model)
    {
        var typeModel = await _typeService.GetById(model.Type.Id);
        var brandModel = await _brandService.GetById(model.Brand.Id);

        if (typeModel == null || brandModel == null)
        {
            throw new Exception("Type or brand does not exist.");
        }

        var entity = _mapper.Map<ProductEntity>(model);
        entity.TypeId = typeModel.Id;
        entity.BrandId = brandModel.Id;

        var addedEntityId = await _productRepository.Add(entity);
        return addedEntityId;
    }

    public async Task<int> Update(int id, ProductModel model)
    {
        var entity = await _productRepository.GetById(id);
        entity.Title = model.Title;
        entity.PictureUrl = model.PictureUrl;
        entity.Price = model.Price;
        entity.TypeId = model.Type.Id;
        entity.BrandId = model.Brand.Id;

        return await _productRepository.Update(entity);
    }

    public async Task<int> Delete(int id)
    {
        return await _productRepository.Delete(id);
    }
}
