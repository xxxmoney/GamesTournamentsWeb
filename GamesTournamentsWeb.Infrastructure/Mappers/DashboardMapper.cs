using AutoMapper;

namespace GamesTournamentsWeb.Infrastructure.Mappers;

public class DashboardMapper : Profile
{
    public DashboardMapper()
    {
        CreateMap<DataAccess.Models.Dashboard.Layout, Dto.Dashboard.Layout>();
        CreateMap<DataAccess.Models.Dashboard.LayoutItem, Dto.Dashboard.LayoutItem>()
            .ForMember(dest => dest.Index, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<ViewModels.Dashboard.LayoutEdit, DataAccess.Models.Dashboard.Layout>();
        CreateMap<ViewModels.Dashboard.LayoutItemEdit, DataAccess.Models.Dashboard.LayoutItem>();
    }
}
