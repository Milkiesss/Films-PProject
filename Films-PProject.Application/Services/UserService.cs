using AutoMapper;
using BCrypt.Net;
using Cinema.Application.DTOs.User.Request;
using Films_PProject.Application.Dtos.UserDto.Request;
using Films_PProject.Application.Dtos.UserDto.Response;
using Films_PProject.Application.Interfaces;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;
using Films_PProject.Domain.Enums;

namespace Films_PProject.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly HashingService _hashingService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IMapper _mapper;

    
    public UserService(IUserRepository userRepository, IMapper mapper, HashingService hashingService, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _hashingService = hashingService;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    
    public async Task<CreateUserResponse> CreateAsync(CreateUserRequest createUserRequest,
        CancellationToken cancellationToken)
    {
        if (await _userRepository.IsExistAsync(createUserRequest.Email,cancellationToken))
            throw new Exception("User is already exists");
        
        var user = _mapper.Map<User>(createUserRequest);
        
        user.Password = await _hashingService.HashPassword(createUserRequest.Password);
        
        await _userRepository.AddAsync(user, cancellationToken);
        return _mapper.Map<CreateUserResponse>(user);
    }
    
    public async Task<string> Login(AutheticationRequest entity,CancellationToken cancellationToken)
    {
        if (!await _userRepository.IsExistAsync(entity.email,cancellationToken))
            throw new Exception("User is not exists");
        var user = await _userRepository.GetByEmailAsync(entity.email,cancellationToken);
       
        if(!await _hashingService.VerifyPassword(entity.password,user.Password))
            throw new BcryptAuthenticationException();
        
        return  _jwtTokenGenerator.GenerateToken(user);
    }
    
    
    public async Task<bool> UpdateRole(Guid userId,RoleType role,CancellationToken cancellationToken )
    { 
        return await _userRepository.UpdateRole(userId,role,cancellationToken);
    }
    
}