using AutoMapper;
using Films_PProject.Application.Dtos.AwardDto.Request;
using Films_PProject.Application.Dtos.AwardDto.Response;
using Films_PProject.Application.Dtos.MovieDto.Response;
using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Mapping;

public class AwardMapProfile : Profile
{
    public AwardMapProfile()
    {
        CreateMap<CreateAwardRequest, Award>()
            .ConstructUsing(dto => new Award(
                Guid.NewGuid(),
                dto.Name,
                dto.AwardStatus,
                dto.Reason
            ));
        CreateMap<UpdateAwardRequest, Award>()
            .ConstructUsing(dto => new Award(
                dto.Id,
                dto.Name,
                dto.AwardStatus,
                dto.Reason
            ));

        CreateMap<Award,UpdateAwardResponse>();
        CreateMap<Award,CreateAwardResponse>();
        
        CreateMap<Award,GetAllAwardResponse>();
    }
}