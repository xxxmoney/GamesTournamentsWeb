using AutoMapper;
using AutoMapper.EquivalencyExpression;

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
        CreateMap<DataAccess.Models.Tournaments.TournamentPlayer, Dto.Tournaments.TournamentPlayer>()
            .ForMember(dest => dest.TournamentName, src => src.MapFrom(item => item.Tournament.Name));
        CreateMap<DataAccess.Models.Tournaments.TournamentPlayerStatus, Dto.Tournaments.TournamentPlayerStatus>();
        
        CreateMap<ViewModels.Tournaments.TournamentEdit, DataAccess.Models.Tournaments.Tournament>()
            .ForMember(dest => dest.Regions, opt => opt.Ignore())
            .ForMember(dest => dest.Admins, opt => opt.Ignore())
            .EqualityComparison((model, dto) => model.Id == dto.Id);
        CreateMap<ViewModels.Tournaments.TournamentPlayerEdit, DataAccess.Models.Tournaments.TournamentPlayer>()
            .EqualityComparison((model, dto) => model.Id == dto.Id);
        CreateMap<ViewModels.Tournaments.PrizeEdit, DataAccess.Models.Tournaments.Prize>()
            .EqualityComparison((model, dto) => model.Id == dto.Id);
        CreateMap<ViewModels.Tournaments.StreamEdit, DataAccess.Models.Tournaments.Stream>()
            .EqualityComparison((model, dto) => model.Id == dto.Id);
    }
    
}
