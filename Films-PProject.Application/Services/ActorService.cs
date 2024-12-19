using AutoMapper;
using Films_PProject.Application.Dtos.ActorDto.Request;
using Films_PProject.Application.Dtos.ActorDto.Response;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Services;

public class ActorService
{
    private readonly IActorRepository _actorRepository;
    private readonly IMapper _mapper;

    public ActorService(IActorRepository actorRepository, IMapper mapper)
    {
        _actorRepository = actorRepository;
        _mapper = mapper;
    }

    public async Task<CreateActorResponse> CreateAsync(CreateActorRequest createActorRequest,
        CancellationToken cancellationToken)
    {
        var actor = _mapper.Map<Actor>(createActorRequest);
        await _actorRepository.AddAsync(actor, cancellationToken);
        return _mapper.Map<CreateActorResponse>(actor);
    }

    public async Task<UpdateActorResponse> UpdateAsync(UpdateActorRequest updateActorRequest,
        CancellationToken cancellationToken)
    {
        var actor = _mapper.Map<Actor>(updateActorRequest);
        await _actorRepository.UpdateAsync(actor, cancellationToken);
        return _mapper.Map<UpdateActorResponse>(actor);
    }

    public async Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken)
    {
        return await _actorRepository.DeleteAsync(Id, cancellationToken);
    }

    public async Task<GetByIdActorResponse> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var actor = await _actorRepository.GetByIdAsync(Id, cancellationToken);
        return _mapper.Map<GetByIdActorResponse>(actor);
    }
    
    public async Task<bool> AwardActorAsync(Guid awardId, Guid winnerId, CancellationToken cancellationToken)
    {
        return await _actorRepository.AwardActorAsync(awardId,winnerId, cancellationToken);
    }

    public async Task<ICollection<GetAllActorResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var actor = await _actorRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<ICollection<GetAllActorResponse>>(actor);
    }
}