using AutoMapper;
using proj1.Dtos.FamiliyDtos;
using proj1.Entity;

namespace proj1.Mappers
{
    public class FamilyMapper : Profile
    {
        public FamilyMapper()
        {
            CreateMap<Family, FamilyReadDto>();
            CreateMap<FamilyReadDto, Family>();
            CreateMap<FamilyCreateDto, Family>();
            CreateMap<FamilyUpdateDto, Family>();
        }
    }
}
