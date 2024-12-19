using AutoMapper;
using Films_PProject.Application.Dtos.ActorDto;
using Films_PProject.Application.Dtos.UserDto.Request;
using Films_PProject.Application.Dtos.UserDto.Response;
using Films_PProject.Domain.Entities;
using Films_PProject.Domain.ValueObject;

namespace Films_PProject.Application.Mapping;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<CreateUserRequest, User>()
            .ConstructUsing(dto => new User(
                Guid.NewGuid(),
                dto.Email,
                dto.Password,
                new FullName(dto.FullName.FirstName, dto.FullName.LastName)
            ));

        CreateMap<User, CreateUserResponse>();
        CreateMap<FullNameDto, FullName>();
        CreateMap<FullName, FullNameDto>();
    }
}