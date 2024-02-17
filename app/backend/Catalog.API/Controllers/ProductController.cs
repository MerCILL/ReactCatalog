namespace Catalog.API.Controllers;

[ApiController]
[Route("catalog/products")]
[Authorize(Policy = "CatalogApiScope")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? page = null, [FromQuery] int? size = null)
    {
        var products = await _productService.Get(page ?? 1, size ?? int.MaxValue);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetById(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductRequest request)
    {
        var model = new ProductModel
        {
            Title = request.Title,
            PictureUrl = request.PictureUrl,
            Price = request.Price,
            Type = new TypeModel
            {
                Id = request.TypeId,
            },
            Brand = new BrandModel
            {
                Id = request.BrandId
            },
            CreatedAt = DateTime.UtcNow
        };

        var addedProductId = await _productService.Add(model);
        return Ok(addedProductId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductRequest request)
    {
        var model = new ProductModel
        {
            Title = request.Title,
            PictureUrl = request.PictureUrl,
            Price = request.Price,
            Type = new TypeModel
            {
                Id = request.TypeId,
            },
            Brand = new BrandModel
            {
                Id = request.BrandId
            },
        };

        var updatedProductId = await _productService.Update(id, model);
        return Ok(updatedProductId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedProductId = await _productService.Delete(id);
        return Ok(deletedProductId);
    }
}
