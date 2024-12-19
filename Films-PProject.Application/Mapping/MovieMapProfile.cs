using AutoMapper;
using Films_PProject.Application.Dtos.MovieDto.Request;
using Films_PProject.Application.Dtos.MovieDto.Response;
using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Mapping;

public class MovieMapProfile : Profile
{
    public MovieMapProfile()
    {
        CreateMap<CreateMovieRequest, Movie>()
            .ConstructUsing(dto => new Movie(
                Guid.NewGuid(),
                dto.Name,
                dto.ReleaseDate,
                dto.TrailerUrl,
                dto.Directors,
                dto.Genres
                ));
        CreateMap<UpdateMovieRequest, Movie>()
            .ConstructUsing(dto => new Movie(
                dto.Id,
                dto.Name,
                dto.ReleaseDate,
                dto.TrailerUrl,
                dto.Directors,
                dto.Genres
            ));

        CreateMap<Movie, CreateMovieResponse>();
        CreateMap<Movie, UpdateMovieResponse>();

        CreateMap<Movie, GetByIdMovieResponce>();
        CreateMap<Movie, GetAllMovieResponce>();
    }
}