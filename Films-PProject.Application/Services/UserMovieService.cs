using AutoMapper;
using Films_PProject.Application.Dtos.UserDto.UserMovies;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Services;

public class UserMovieService
{
    private readonly IUserMovieRepository _userMovieRepository;
    private readonly IMapper _mapper;

    public UserMovieService(IUserMovieRepository userMovieRepository, IMapper mapper)
    {
        _userMovieRepository = userMovieRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateUserMovieAsync(CreateUserMovieRequest createUserActorRequest, CancellationToken cancellationToken)
    {
        var userMovie = _mapper.Map<UserMovies>(createUserActorRequest);
        await _userMovieRepository.AddFavoriteMovieAsync(userMovie,cancellationToken);
        return true;
    }
    public async Task<bool> DeleteUserMovieAsync(DeleteUserMovieRequest deleteUserMovieRequest, CancellationToken cancellationToken)
    {
        var userMovie = _mapper.Map<UserMovies>(deleteUserMovieRequest);
        await _userMovieRepository.DeleteFavoriteMovieAsync(userMovie,cancellationToken);
        return true;
    }
    public async Task<ICollection<GetAllUserMovieResponce>> GetUserMovieAsync(Guid userId, CancellationToken cancellationToken)
    {
        var userMovie = await _userMovieRepository.GetAllUserMoviesAsync(userId,cancellationToken);
        return _mapper.Map<ICollection<GetAllUserMovieResponce>>(userMovie);
    }
}