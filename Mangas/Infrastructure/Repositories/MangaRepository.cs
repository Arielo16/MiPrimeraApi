using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class MangaRepository
{
    private readonly string _dataFilePath;
    private List<Manga> _mangas;

    public MangaRepository(IConfiguration configuration)
    {
        _dataFilePath = configuration["dataBank"];
        LoadData();
    }

    private void LoadData()
    {
        if (File.Exists(_dataFilePath))
        {
            var jsonData = File.ReadAllText(_dataFilePath);
            _mangas = JsonConvert.DeserializeObject<List<Manga>>(jsonData);
        }
        else
        {
            _mangas = new List<Manga>();
        }
    }

    public List<Manga> GetAll() => _mangas;

    public Manga GetById(int id) => _mangas.Find(m => m.Id == id);

    public void Add(Manga manga)
    {
        _mangas.Add(manga);
        SaveData();
    }

    public void Update(Manga manga)
    {
        var existingManga = GetById(manga.Id);
        if (existingManga != null)
        {
            existingManga.Titulo = manga.Titulo;
            existingManga.Autor = manga.Autor;
            existingManga.Genero = manga.Genero;
            SaveData();
        }
    }

    public void Delete(int id)
    {
        _mangas.RemoveAll(m => m.Id == id);
        SaveData();
    }

    private void SaveData()
    {
        var jsonData = JsonConvert.SerializeObject(_mangas, Formatting.Indented);
        File.WriteAllText(_dataFilePath, jsonData);
    }
}