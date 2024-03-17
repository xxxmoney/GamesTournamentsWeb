using AutoMapper;

namespace GamesTournamentsWeb.Infrastructure.Mappers;

public class GameMapper : Profile
{
    public GameMapper()
    {
        CreateMap<DataAccess.Models.Games.Genre, Dto.Genre>();
        
        // TODO: add other mappings
    }
}