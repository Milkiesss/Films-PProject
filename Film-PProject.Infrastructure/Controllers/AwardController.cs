using Films_PProject.Application.Dtos.AwardDto.Request;
using Films_PProject.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Film_PProject.Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwardController : ControllerBase
{
    private readonly AwardService _awardService;
    public AwardController(AwardService awardService)
    {
        _awardService = awardService;
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(CreateAwardRequest request,CancellationToken cancellationToken)
    {
        var result = await _awardService.CreateAsync(request,cancellationToken);
        return Ok(result);
    }
    [Authorize(Roles = "Admin")]
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync(UpdateAwardRequest request,CancellationToken cancellationToken)
    {
        var result = await _awardService.UpdateAsync(request,cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _awardService.GetAllAsync(cancellationToken);
        return Ok(result);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync(Guid awardId,CancellationToken cancellationToken)
    {
        var result = await _awardService.DeleteAsync(awardId,cancellationToken);
        return Ok(result);
    }
    
}