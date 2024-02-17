namespace Catalog.API.Abstractions.Repositories;

public interface IBrandRepository
{
    Task<IEnumerable<BrandEntity>> Get(int page, int size);
    Task<int> Add(BrandEntity brandEntity);
    Task<int> Delete(int id);
    Task<BrandEntity> GetById(int id);
    Task<int> Update(BrandEntity brandEntity);
}