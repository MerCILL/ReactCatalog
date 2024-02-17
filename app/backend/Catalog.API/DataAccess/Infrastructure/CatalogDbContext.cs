namespace Catalog.API.DataAccess.Infrastructure;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
            
    }

    public DbSet<TypeEntity> Types { get; set; }
    public DbSet<BrandEntity> Brands { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TypeEntityConfiguration());
        builder.ApplyConfiguration(new BrandEntityConfiguration());
        builder.ApplyConfiguration(new ProductEntityConfiguration());

        CatalogDbSeed.Seed(builder);
    }

}
