using System.Security.Claims;
using Films_PProject.Application.Dtos.UserDto.UserMovies;
using Films_PProject.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Film_PProject.Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserMoviesController : ControllerBase
{
    private readonly UserMovieService _userMovieService;

    public UserMoviesController(UserMovieService userMovieService)
    {
        _userMovieService = userMovieService;
    }
    
    [Authorize]
    [HttpPost("AddFavoriteMovie")]
    public async Task<IActionResult> AddFavoriteMovie(CreateUserMovieRequest request,CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        request.UserId = Guid.Parse(userId);
        var result = await _userMovieService.CreateUserMovieAsync(request,cancellationToken);
        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("GetFavoriteMovies")]
    public async Task<IActionResult> GetFavoriteMovies(CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _userMovieService.GetUserMovieAsync(Guid.Parse(userId),cancellationToken);
        return Ok(result);
    }
    
    [Authorize]
    [HttpDelete("DeleteFavoriteMovie")]
    public async Task<IActionResult> DeleteFavoriteMovie(DeleteUserMovieRequest request,CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        request.UserId = Guid.Parse(userId);
        var result = await _userMovieService.DeleteUserMovieAsync(request,cancellationToken);
        return Ok(result);
    }
}