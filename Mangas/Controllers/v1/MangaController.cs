using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/v1/[controller]")]
public class MangaController : ControllerBase
{
    private readonly MangaService _mangaService;
    private readonly IMapper _mapper;

    public MangaController(MangaService mangaService, IMapper mapper)
    {
        _mangaService = mangaService;
        _mapper = mapper;
    }

    // Método GET para obtener todos los mangas
    [HttpGet]
    public IActionResult GetAll()
    {
        var mangas = _mangaService.GetAll();
        var mangasDTO = _mapper.Map<List<MangaDTO>>(mangas);
        return Ok(mangasDTO);
    }

    // Método GET para obtener un manga por su ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var manga = _mangaService.GetById(id);
        if (manga == null)
        {
            return NotFound();
        }

        var mangaDTO = _mapper.Map<MangaDTO>(manga);
        return Ok(mangaDTO);
    }

    // Método POST para agregar un nuevo manga
    [HttpPost]
    public IActionResult Add([FromBody] MangaCreateDTO mangaCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var manga = _mapper.Map<Manga>(mangaCreateDTO);
        _mangaService.Add(manga);
        return Ok();
    }

    // Método PUT para actualizar un manga existente
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] MangaCreateDTO mangaCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var manga = _mapper.Map<Manga>(mangaCreateDTO);
        manga.Id = id;
        _mangaService.Update(manga);
        return Ok();
    }

    // Método DELETE para eliminar un manga por su ID
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var manga = _mangaService.GetById(id);
        if (manga == null)
        {
            return NotFound();
        }

        _mangaService.Delete(id);
        return Ok();
    }
}
