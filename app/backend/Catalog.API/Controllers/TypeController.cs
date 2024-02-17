namespace Catalog.API.Controllers;

[ApiController]
[Route("catalog/types")]
[Authorize(Policy = "CatalogApiScope")]
public class TypeController : ControllerBase
{
    private readonly ITypeService _typeService;

    public TypeController(ITypeService typeService)
    {
        _typeService = typeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? page = null, [FromQuery] int? size = null)
    {
        var types = await _typeService.Get(page ?? 1, size ?? int.MaxValue);
        return Ok(types);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var type = await _typeService.GetById(id);
        return Ok(type);
    }

    [HttpPost]
    public async Task<IActionResult> Add(TypeRequest request)
    {
        var model = new TypeModel
        {
            Title = request.Title,
        };

        var addedTypeId = await _typeService.Add(model);
        return Ok(addedTypeId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TypeRequest request)
    {
        var model = new TypeModel
        {
            Title = request.Title
        };

        var updatedTypeId = await _typeService.Update(id, model);
        return Ok(updatedTypeId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedTypeId = await _typeService.Delete(id);
        return Ok(deletedTypeId);
    }
}
