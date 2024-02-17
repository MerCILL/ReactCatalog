namespace Catalog.API.Abstractions.Services
{
    public interface ITypeService
    {
        Task<int> Add(TypeModel model);
        Task<int> Delete(int id);
        Task<IEnumerable<TypeModel>> Get(int page, int size);
        Task<TypeModel> GetById(int id);
        Task<int> Update(int id, TypeModel model);
    }
}