using AutoMapper;
using Films_PProject.Application.Dtos.ActorDto;
using Films_PProject.Application.Dtos.ActorDto.Request;
using Films_PProject.Application.Dtos.ActorDto.Response;
using Films_PProject.Application.Dtos.MovieDto.Request;
using Films_PProject.Application.Dtos.MovieDto.Response;
using Films_PProject.Domain.Entities;
using Films_PProject.Domain.ValueObject;

namespace Films_PProject.Application.Mapping;

public class ActorMapProfile : Profile
{
    public ActorMapProfile()
    {

        CreateMap<CreateActorRequest, Actor>()
            .ConstructUsing(dto => new Actor(
                Guid.NewGuid(),
                new FullName(dto.FullName.FirstName, dto.FullName.LastName),
                dto.BirthDay,
                dto.PlaceOfBirth
            ));
        CreateMap<UpdateActorRequest, Actor>()
            .ConstructUsing(dto => new Actor(
                dto.Id,
                new FullName(dto.FullName.FirstName, dto.FullName.LastName),
                dto.BirthDay,
                dto.PlaceOfBirth
            ));

        CreateMap<Actor,UpdateActorResponse>();
        CreateMap<Actor,CreateActorResponse>();

        CreateMap<Actor,GetAllActorResponse>();
        CreateMap<Actor,GetByIdActorResponse>();
        CreateMap<FullNameDto, FullName>();
        CreateMap<FullName, FullNameDto>();
    }
    
}