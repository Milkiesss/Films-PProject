using AutoMapper;
using Films_PProject.Application.Dtos.UserDto.UserActors;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Services;

public class UserActorService
{
    private readonly IUserActorRepository _userActorRepository;
    private readonly IMapper _mapper;

    public UserActorService(IUserActorRepository userActorRepository, IMapper mapper)
    {
        _userActorRepository = userActorRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateUserActorAsync(CreateUserActorRequest createUserActorRequest, CancellationToken cancellationToken)
    {
        var userActor = _mapper.Map<UserActors>(createUserActorRequest);
        await _userActorRepository.AddFavoriteActorAsync(userActor,cancellationToken);
        return true;
    }
    public async Task<bool> DeleteUserActorAsync(DeleteUserActorRequest deleteUserActorRequest, CancellationToken cancellationToken)
    {
        var userActor = _mapper.Map<UserActors>(deleteUserActorRequest);
        await _userActorRepository.DeleteFavoriteActorAsync(userActor,cancellationToken);
        return true;
    }
    public async Task<ICollection<GetAllUserActorResponse>> GetUserActorAsync(Guid userId, CancellationToken cancellationToken)
    {
        var userActor =await _userActorRepository.GetAllUserActorAsync(userId,cancellationToken);
        return  _mapper.Map<ICollection<GetAllUserActorResponse>>(userActor);;
    }
}