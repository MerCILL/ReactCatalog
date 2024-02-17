namespace Catalog.API.DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _catalogDbContext;

    public ProductRepository(CatalogDbContext catalogDbContext)
    {
        _catalogDbContext = catalogDbContext;
    }

    public async Task<IEnumerable<ProductEntity>> Get(int page, int size)
    {
        return await _catalogDbContext.Products
            .AsNoTracking()
            .Include(t => t.Type)
            .Include(b => b.Brand)
            .OrderBy(b => b.Id)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }

    public async Task<ProductEntity> GetById(int id)
    {
        return await _catalogDbContext.Products
            .Include(t => t.Type)
            .Include(b => b.Brand)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<int> Add(ProductEntity productEntity)
    {
        await _catalogDbContext.Products.AddAsync(productEntity);
        await _catalogDbContext.SaveChangesAsync();
        return productEntity.Id;
    }

    public async Task<int> Update(ProductEntity productEntity)
    {
        _catalogDbContext.Products.Update(productEntity);
        await _catalogDbContext.SaveChangesAsync();
        return productEntity.Id;
    }

    public async Task<int> Delete(int id)
    {
        var productEntity = await GetById(id);
        _catalogDbContext.Products.Remove(productEntity);
        await _catalogDbContext.SaveChangesAsync();
        return productEntity.Id;
    }
}
