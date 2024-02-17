namespace Catalog.API.DataAccess.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public int TypeId { get; set; }
    public TypeEntity Type { get; set; } = null!;
    public int BrandId { get; set; }
    public BrandEntity Brand { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
