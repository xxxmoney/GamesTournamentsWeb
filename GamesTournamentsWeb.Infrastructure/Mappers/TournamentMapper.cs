using AutoMapper;

namespace GamesTournamentsWeb.Infrastructure.Mappers;

public class TournamentMapper : Profile
{
    public TournamentMapper()
    {
        CreateMap<DataAccess.Models.Tournaments.Currency, Dto.Tournaments.Currency>();
        CreateMap<DataAccess.Models.Tournaments.Match, Dto.Tournaments.Match>();
        CreateMap<DataAccess.Models.Tournaments.Platform, Dto.Tournaments.Platform>();
        CreateMap<DataAccess.Models.Tournaments.Prize, Dto.Tournaments.Prize>();
        CreateMap<DataAccess.Models.Tournaments.Region, Dto.Tournaments.Region>();
        CreateMap<DataAccess.Models.Tournaments.Stream, Dto.Tournaments.Stream>();
        CreateMap<DataAccess.Models.Tournaments.Team, Dto.Tournaments.Team>();
        CreateMap<DataAccess.Models.Tournaments.Tournament, Dto.Tournaments.Tournament>();
        CreateMap<DataAccess.Models.Tournaments.TournamentOverview, Dto.Tournaments.TournamentOverview>();
        CreateMap<DataAccess.Models.Tournaments.TournamentPlayer, Dto.Tournaments.TournamentPlayer>();
        CreateMap<DataAccess.Models.Tournaments.TournamentPlayerStatus, Dto.Tournaments.TournamentPlayerStatus>();
        
        CreateMap<ViewModels.Tournaments.TournamentEdit, DataAccess.Models.Tournaments.Tournament>();
        CreateMap<ViewModels.Tournaments.TournamentPlayerEdit, DataAccess.Models.Tournaments.TournamentPlayer>();
        CreateMap<ViewModels.Tournaments.PrizeEdit, DataAccess.Models.Tournaments.Prize>();
        CreateMap<ViewModels.Tournaments.StreamEdit, DataAccess.Models.Tournaments.Stream>();
    }
    
}
