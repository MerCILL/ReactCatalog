namespace Catalog.API.Abstractions.Repositories;

public interface ITypeRepository
{
    Task<IEnumerable<TypeEntity>> Get(int page, int size);
    Task<int> Add(TypeEntity typeEntity);
    Task<int> Delete(int id);
    Task<TypeEntity> GetById(int id);
    Task<int> Update(TypeEntity entity);
}