using AutoMapper;
using Films_PProject.Application.Dtos.UserDto.UserActors;
using Films_PProject.Application.Dtos.UserDto.UserMovies;
using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Mapping;

public class UserMovieMapProfile : Profile
{
    public UserMovieMapProfile()
    {
        CreateMap<CreateUserMovieRequest, UserMovies>();
        CreateMap<DeleteUserMovieRequest, UserMovies>();
        CreateMap<UserMovies,GetAllUserMovieResponce>();
    }
}