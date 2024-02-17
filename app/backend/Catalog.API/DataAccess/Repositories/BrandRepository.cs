namespace Catalog.API.DataAccess.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly CatalogDbContext _catalogDbContext;

    public BrandRepository(CatalogDbContext catalogDbContext)
    {
        _catalogDbContext = catalogDbContext;
    }

    public async Task<IEnumerable<BrandEntity>> Get(int page, int size)
    {
        return await _catalogDbContext.Brands
            .AsNoTracking()
            .OrderBy(b => b.Id)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }

    public async Task<BrandEntity> GetById(int id)
    {
        return await _catalogDbContext.Brands.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<int> Add(BrandEntity brandEntity)
    {
        await _catalogDbContext.Brands.AddAsync(brandEntity);
        await _catalogDbContext.SaveChangesAsync();
        return brandEntity.Id;
    }

    public async Task<int> Update(BrandEntity brandEntity)
    {
        _catalogDbContext.Brands.Update(brandEntity);
        await _catalogDbContext.SaveChangesAsync();
        return brandEntity.Id;
    }

    public async Task<int> Delete(int id)
    {
        var brandEntity = await GetById(id);
        _catalogDbContext.Brands.Remove(brandEntity);
        await _catalogDbContext.SaveChangesAsync();
        return brandEntity.Id;
    }
}
