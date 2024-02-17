namespace Catalog.API.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public TypeModel Type { get; set; } = null!;
    public BrandModel Brand { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
