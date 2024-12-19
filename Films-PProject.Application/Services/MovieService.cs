using AutoMapper;
using Films_PProject.Application.Dtos.MovieDto.Request;
using Films_PProject.Application.Dtos.MovieDto.Response;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Services;

public class MovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;


    public MovieService(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }


    public async Task<CreateMovieResponse> CreateAsync(CreateMovieRequest createMovieRequest,
        CancellationToken cancellationToken)
    {
        var movie = _mapper.Map<Movie>(createMovieRequest);
        await _movieRepository.AddAsync(movie, cancellationToken);
        return _mapper.Map<CreateMovieResponse>(movie);
    }


    public async Task<UpdateMovieResponse> UpdateAsync(UpdateMovieRequest updateMovieRequest,
        CancellationToken cancellationToken)
    {
        var movie = _mapper.Map<Movie>(updateMovieRequest);
        await _movieRepository.UpdateAsync(movie, cancellationToken);
        return _mapper.Map<UpdateMovieResponse>(movie);
    }


    public async Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken)
    {
        return await _movieRepository.DeleteAsync(Id, cancellationToken);
    }


    public async Task<GetByIdMovieResponce> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByIdAsync(Id, cancellationToken);
        return _mapper.Map<GetByIdMovieResponce>(movie);
    }

    public async Task<bool> AwardMovieAsync(Guid awardId, Guid winnerId, CancellationToken cancellationToken)
    {
        return await _movieRepository.AwardMovieAsync(awardId,winnerId, cancellationToken);
    }

    public async Task<ICollection<GetAllMovieResponce>> GetAllAsync(CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<ICollection<GetAllMovieResponce>>(movie);
    }
}
