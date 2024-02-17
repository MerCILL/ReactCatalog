namespace Catalog.API.Abstractions.Services
{
    public interface IProductService
    {
        Task<int> Add(ProductModel model);
        Task<int> Delete(int id);
        Task<IEnumerable<ProductModel>> Get(int page, int size);
        Task<ProductModel> GetById(int id);
        Task<int> Update(int id, ProductModel model);
    }
}