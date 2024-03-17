using AutoMapper;

namespace GamesTournamentsWeb.Infrastructure.Mappers;

public class GameMapper : Profile
{
    public GameMapper()
    {
        CreateMap<DataAccess.Models.Games.Game, Dto.Games.Game>();
        CreateMap<DataAccess.Models.Games.GameOverview, Dto.Games.GameOverview>();
        CreateMap<DataAccess.Models.Games.Genre, Dto.Games.Genre>();
    }
}