using AutoMapper;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {
        CreateMap<MangaCreateDTO, Manga>()
            .AfterMap((src, dest) => dest.PublicationDate = src.PublicationDate);
    }
}
