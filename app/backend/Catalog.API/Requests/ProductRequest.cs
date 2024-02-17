namespace Catalog.API.Requests;

public class ProductRequest
{
    public string Title { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int TypeId { get; set; }
    public int BrandId { get; set; }
}
