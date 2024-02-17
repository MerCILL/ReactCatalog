namespace Catalog.API.Controllers;

[ApiController]
[Route("catalog/brands")]
[Authorize(Policy = "CatalogApiScope")]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? page = null, [FromQuery] int? size = null)
    {
        var brands = await _brandService.Get(page ?? 1, size ?? int.MaxValue);
        return Ok(brands);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var brand = await _brandService.GetById(id);
        return Ok(brand);
    }

    [HttpPost]
    public async Task<IActionResult> Add(BrandRequest request)
    {
        var model = new BrandModel
        {
            Title = request.Title,
        };

        var addedBrandId = await _brandService.Add(model);
        return Ok(addedBrandId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, BrandRequest request)
    {
        var model = new BrandModel
        {
            Title = request.Title
        };

        var updatedBrandId = await _brandService.Update(id, model);
        return Ok(updatedBrandId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedBrandId = await _brandService.Delete(id);
        return Ok(deletedBrandId);
    }
}
