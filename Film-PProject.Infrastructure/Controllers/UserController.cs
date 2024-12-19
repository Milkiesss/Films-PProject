using System.Security.Claims;
using Cinema.Application.DTOs.User.Request;
using Films_PProject.Application.Dtos.UserDto.Request;
using Films_PProject.Application.Services;
using Films_PProject.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Film_PProject.Infrastructure.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(CreateUserRequest request,CancellationToken cancellationToken)
    {
        var result = await _userService.CreateAsync(request,cancellationToken);
        return Ok(result);
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> DeleteAsync(AutheticationRequest request,CancellationToken cancellationToken)
    {
        var result = await _userService.Login(request,cancellationToken);
        return Ok(result);
    }
    
    [Authorize]
    [HttpPut("UpdateRole")]
    public async Task<IActionResult> UpdateRole(RoleType roleType,CancellationToken cancellationToken)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await _userService.UpdateRole(Guid.Parse(userId), roleType,cancellationToken);
        return Ok(result);
    }
}