namespace Catalog.API.Abstractions.Services
{
    public interface IBrandService
    {
        Task<int> Add(BrandModel model);
        Task<int> Delete(int id);
        Task<IEnumerable<BrandModel>> Get(int page, int size);
        Task<BrandModel> GetById(int id);
        Task<int> Update(int id, BrandModel model);
    }
}