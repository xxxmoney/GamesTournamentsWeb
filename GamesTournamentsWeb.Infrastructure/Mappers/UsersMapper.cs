using AutoMapper;

namespace GamesTournamentsWeb.Infrastructure.Mappers;

public class UsersMapper : Profile
{
    public UsersMapper()
    {
        CreateMap<DataAccess.Models.Users.Account, Dto.Users.Account>();
        CreateMap<DataAccess.Models.Users.Role, Dto.Users.Role>();
    }
}