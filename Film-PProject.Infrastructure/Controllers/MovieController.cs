using Films_PProject.Application.Dtos.MovieDto.Request;
using Films_PProject.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Film_PProject.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;
        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateMovieRequest request,CancellationToken cancellationToken)
        {
            var result = await _movieService.CreateAsync(request,cancellationToken);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UpdateMovieRequest request,CancellationToken cancellationToken)
        {
            var result = await _movieService.UpdateAsync(request,cancellationToken);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("AwardMovie")]
        public async Task<IActionResult> AwardMovieAsync(Guid awardId, Guid winnerId,CancellationToken cancellationToken)
        {
            var result = await _movieService.AwardMovieAsync(awardId,winnerId,cancellationToken);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("{movieId:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid movieId,CancellationToken cancellationToken)
        {
            var result = await _movieService.GetByIdAsync(movieId,cancellationToken);
            return Ok(result);
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _movieService.GetAllAsync(cancellationToken);
            return Ok(result);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(Guid movieId,CancellationToken cancellationToken)
        {
            var result = await _movieService.DeleteAsync(movieId,cancellationToken);
            return Ok(result);
        }
    }
}

