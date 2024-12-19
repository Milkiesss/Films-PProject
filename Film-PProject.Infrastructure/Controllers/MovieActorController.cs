using Films_PProject.Application.Dtos.MovieActorDto.Request;
using Films_PProject.Application.Dtos.MovieDto.Request;
using Films_PProject.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Film_PProject.Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieActorController : ControllerBase
{
    private readonly MovieActorService _movieActorService;

    public MovieActorController(MovieActorService movieActorService)
    {
        _movieActorService = movieActorService;
    }
    [Authorize(Roles = "Admin")]
    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(CreateMovieActorRequest request,CancellationToken cancellationToken)
    {
        var result = await _movieActorService.AddMovieActorAsync(request,cancellationToken);
        return Ok(result);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteActorFromMovieAsync(DeleteMovieActorRequest request,CancellationToken cancellationToken)
    {
        var result = await _movieActorService.DeleteActorFromMovieAsync(request,cancellationToken);
        return Ok(result);
    }
}