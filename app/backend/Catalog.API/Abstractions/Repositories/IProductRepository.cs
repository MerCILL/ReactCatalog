namespace Catalog.API.Abstractions.Repositories;

public interface IProductRepository
{
    Task<int> Add(ProductEntity productEntity);
    Task<int> Delete(int id);
    Task<IEnumerable<ProductEntity>> Get(int page, int size);
    Task<ProductEntity> GetById(int id);
    Task<int> Update(ProductEntity productEntity);
}