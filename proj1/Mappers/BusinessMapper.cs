using AutoMapper;
using proj1.Dtos.BusinessDtos;
using proj1.Entity;

namespace proj1.Mappers
{
    public class BusinessMapper : Profile
    {
        public BusinessMapper()
        {

            CreateMap<Business, BusinessReadDto>();
            CreateMap<BusinessReadDto, Business>();
            CreateMap<BusinessCreateDto, Business>();
            CreateMap<BusinessUpdateDto, Business>();
        }
    }
}
