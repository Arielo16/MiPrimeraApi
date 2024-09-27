using AutoMapper;

public class ResponseMappingProfile : Profile
{
    public ResponseMappingProfile()
    {
        CreateMap<Manga, MangaDTO>()
            .ForMember(dest => dest.PublicationYear, opt => opt.MapFrom(src => src.PublicationDate.Year));
    }
}
