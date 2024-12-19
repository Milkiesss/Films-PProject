using AutoMapper;
using Films_PProject.Application.Dtos.MovieActorDto.Request;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Services;

public class MovieActorService
{
    private readonly IMovieActorRepository _movieActorRepository;
    private readonly IMapper _mapper;
    
    public MovieActorService(IMovieActorRepository movieActorRepository, IMapper mapper)
    {
        _movieActorRepository = movieActorRepository;
        _mapper = mapper;
    }

    public async Task<bool> AddMovieActorAsync(CreateMovieActorRequest createMovieActorRequest,CancellationToken cancellationToken )
    {
        var movieActor = _mapper.Map<MovieActor>(createMovieActorRequest);
        await _movieActorRepository.AddAsync(movieActor,cancellationToken);
        return true;
    }
    public async Task<bool> DeleteActorFromMovieAsync(DeleteMovieActorRequest deleteMovieActorRequest,CancellationToken cancellationToken )
    {
        var movieActor = _mapper.Map<MovieActor>(deleteMovieActorRequest);
        return await _movieActorRepository.DeleteActorFromMovieAsync(movieActor,cancellationToken);
    }
}