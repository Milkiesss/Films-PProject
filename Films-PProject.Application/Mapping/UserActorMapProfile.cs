using AutoMapper;
using Films_PProject.Application.Dtos.ActorDto.Request;
using Films_PProject.Application.Dtos.UserDto.UserActors;
using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Mapping;

public class UserActorMapProfile : Profile
{
    public UserActorMapProfile()
    {
        CreateMap<CreateUserActorRequest, UserActors>();
        CreateMap<DeleteUserActorRequest, UserActors>();
        CreateMap<UserActors,GetAllUserActorResponse>();
    }
}