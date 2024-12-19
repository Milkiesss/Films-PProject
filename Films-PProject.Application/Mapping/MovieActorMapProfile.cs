using AutoMapper;
using Films_PProject.Application.Dtos.MovieActorDto;
using Films_PProject.Application.Dtos.MovieActorDto.Request;
using Films_PProject.Application.Dtos.MovieDto.Request;
using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Mapping;

public class MovieActorMapProfile : Profile
{
    public MovieActorMapProfile()
    {
        CreateMap<CreateMovieActorRequest, MovieActor>();
        CreateMap<DeleteMovieActorRequest, MovieActor>();
        CreateMap<MovieActor, BaseMovieActorDto>();
    }
}