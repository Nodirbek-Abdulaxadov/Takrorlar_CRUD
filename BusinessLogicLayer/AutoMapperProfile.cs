using AutoMapper;
using BusinessLogicLayer.Dtos.Auth;
using BusinessLogicLayer.Dtos.Computer;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Computer, ComputerDto>()
            .ReverseMap();

        CreateMap<AddComputerDto, Computer>();

        CreateMap<RegisterUserDto, User>();
        CreateMap<LoginUserDto, User>();
    }
}