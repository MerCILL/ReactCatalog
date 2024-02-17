namespace Catalog.API.DataAccess.Repositories;

public class TypeRepository : ITypeRepository
{
    private readonly CatalogDbContext _catalogDbContext;

    public TypeRepository(CatalogDbContext catalogDbContext)
    {
        _catalogDbContext = catalogDbContext;
    }

    public async Task<IEnumerable<TypeEntity>> Get(int page, int size)
    {
        return await _catalogDbContext.Types
            .AsNoTracking()
            .OrderBy(t => t.Id)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }

    public async Task<TypeEntity> GetById(int id)
    {
        return await _catalogDbContext.Types.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<int> Add(TypeEntity typeEntity)
    {
        await _catalogDbContext.Types.AddAsync(typeEntity);
        await _catalogDbContext.SaveChangesAsync();
        return typeEntity.Id;
    }

    public async Task<int> Update(TypeEntity entity)
    {
        _catalogDbContext.Types.Update(entity);
        await _catalogDbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<int> Delete(int id)
    {
        var typeEntity = await GetById(id);
        _catalogDbContext.Types.Remove(typeEntity);
        await _catalogDbContext.SaveChangesAsync();
        return typeEntity.Id;
    }
}
