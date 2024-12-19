using System.Security.Claims;
using Films_PProject.Application.Dtos.UserDto.UserActors;
using Films_PProject.Application.Dtos.UserDto.UserMovies;
using Films_PProject.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Film_PProject.Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserActorController : ControllerBase
{
    private readonly UserActorService _userActorService;

    public UserActorController(UserActorService userActorService)
    {
        _userActorService = userActorService;
    }
    
    [Authorize]
    [HttpPost("AddFavoriteActor")]
    public async Task<IActionResult> AddFavoriteActor(CreateUserActorRequest request,CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        request.UserId = Guid.Parse(userId);
        var result = await _userActorService.CreateUserActorAsync(request,cancellationToken);
        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("GetFavoriteActor")]
    public async Task<IActionResult> GetFavoriteActor(CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _userActorService.GetUserActorAsync(Guid.Parse(userId),cancellationToken);
        return Ok(result);
    }
    
    [Authorize]
    [HttpDelete("DeleteFavoriteActor")]
    public async Task<IActionResult> DeleteFavoriteActor(DeleteUserActorRequest request,CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        request.UserId = Guid.Parse(userId);
        var result = await _userActorService.DeleteUserActorAsync(request,cancellationToken);
        return Ok(result);
    }
}