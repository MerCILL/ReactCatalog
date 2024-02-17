namespace Catalog.API.DataAccess.Infrastructure;

public static class CatalogDbSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var types = new List<TypeEntity>()
        {
            new TypeEntity { Id = 1, Title = "Hoodie" },
            new TypeEntity { Id = 2, Title = "Shoes" }
        };

        var brands = new List<BrandEntity>()
        {
            new BrandEntity { Id = 1, Title = "Nike" },
            new BrandEntity { Id = 2, Title = "Jordan"}
        };

        var products = new List<ProductEntity>()
        {
            new ProductEntity { Id = 1, Title = "Nike Air Max 97", PictureUrl = "nike-air-max-97-lightblue.png", Price = 100, TypeId = 2, BrandId = 1, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 2, Title = "Nike Air Max Pulse Drift", PictureUrl = "nike-air-max-pulse-drift-red.png", Price = 150, TypeId = 2, BrandId = 1, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 3, Title = "Air Jordan 13 Retro", PictureUrl = "air-jordan-13-retro-bluegrey.png", Price = 200, TypeId = 2, BrandId = 2, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 4, Title = "Miami Hear Courtside Statement Edition", PictureUrl = "miami-heat-courtside-statement-edition.png", Price = 80, TypeId = 1, BrandId = 2, CreatedAt = DateTime.UtcNow }
        };

        builder.Entity<TypeEntity>().HasData(types);
        builder.Entity<BrandEntity>().HasData(brands);
        builder.Entity<ProductEntity>().HasData(products);
    }
}
