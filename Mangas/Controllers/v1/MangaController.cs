using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class MangaController : ControllerBase
{
    private readonly MangaService _mangaService;

    public MangaController(MangaService mangaService)
    {
        _mangaService = mangaService;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_mangaService.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(_mangaService.GetById(id));

    [HttpPost]
    public IActionResult Add([FromBody] Manga manga)
    {
        _mangaService.Add(manga);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update([FromBody] Manga manga)
    {
        _mangaService.Update(manga);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _mangaService.Delete(id);
        return Ok();
    }
}
