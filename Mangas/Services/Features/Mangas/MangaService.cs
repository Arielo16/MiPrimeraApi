using System.Collections.Generic;

public class MangaService
{
    private readonly MangaRepository _mangaRepository;

    public MangaService(MangaRepository mangaRepository)
    {
        _mangaRepository = mangaRepository;
    }

    public List<Manga> GetAll()
    {
        return _mangaRepository.GetAll();
    }

    public Manga GetById(int id)
    {
        return _mangaRepository.GetById(id);
    }

    public void Add(Manga manga)
    {
        _mangaRepository.Add(manga);
    }

    public void Update(Manga manga)
    {
        _mangaRepository.Update(manga);
    }

    public void Delete(int id)
    {
        _mangaRepository.Delete(id);
    }
}
