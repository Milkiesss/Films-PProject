using AutoMapper;
using Films_PProject.Application.Dtos.AwardDto.Request;
using Films_PProject.Application.Dtos.AwardDto.Response;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Services;

public class AwardService
{
    private readonly IAwardRepository _awardRepository;
    private readonly IMapper _mapper;

    public AwardService(IAwardRepository awardRepository, IMapper mapper)
    {
        _awardRepository = awardRepository;
        _mapper = mapper;
    }

    public async Task<CreateAwardResponse> CreateAsync(CreateAwardRequest createAwardRequest,
        CancellationToken cancellationToken)
    {
        var award = _mapper.Map<Award>(createAwardRequest);
        await _awardRepository.AddAsync(award, cancellationToken);
        return _mapper.Map<CreateAwardResponse>(award);
    }

    public async Task<UpdateAwardResponse> UpdateAsync(UpdateAwardRequest updateAwardRequest,
        CancellationToken cancellationToken)
    {
        var award = _mapper.Map<Award>(updateAwardRequest);
        await _awardRepository.UpdateAsync(award, cancellationToken);
        return _mapper.Map<UpdateAwardResponse>(award);
    }

    public async Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken)
    {
        return await _awardRepository.DeleteAsync(Id, cancellationToken);
    }

    public async Task<ICollection<GetAllAwardResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var award = await _awardRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<ICollection<GetAllAwardResponse>>(award);
    }
}