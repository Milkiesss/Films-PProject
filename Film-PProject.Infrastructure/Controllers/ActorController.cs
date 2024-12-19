using Films_PProject.Application.Dtos.ActorDto.Request;
using Films_PProject.Application.Dtos.MovieDto.Request;
using Films_PProject.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Film_PProject.Infrastructure.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ActorController : ControllerBase
{
    private readonly ActorService _actorService;
    public ActorController(ActorService actorService)
    {
        _actorService = actorService;
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(CreateActorRequest request,CancellationToken cancellationToken)
    {
        var result = await _actorService.CreateAsync(request,cancellationToken);
        return Ok(result);
    }
    [Authorize(Roles = "Admin")]
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync(UpdateActorRequest request,CancellationToken cancellationToken)
    {
        var result = await _actorService.UpdateAsync(request,cancellationToken);
        return Ok(result);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPut("AwardActor")]
    public async Task<IActionResult> AwardActorAsync(Guid awardId, Guid winnerId,CancellationToken cancellationToken)
    {
        var result = await _actorService.AwardActorAsync(awardId,winnerId,cancellationToken);
        return Ok(result);
    }
    [HttpGet("{actorId:guid}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid actorId,CancellationToken cancellationToken)
    {
        var result = await _actorService.GetByIdAsync(actorId,cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _actorService.GetAllAsync(cancellationToken);
        return Ok(result);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync(Guid actorId,CancellationToken cancellationToken)
    {
        var result = await _actorService.DeleteAsync(actorId,cancellationToken);
        return Ok(result);
    }
    
}