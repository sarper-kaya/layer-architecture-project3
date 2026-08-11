using AutoMapper;
using proj1.Dtos.RelationsDtos;
using proj1.Entity;

namespace proj1.Mappers
{
    public class RelationsMapper : Profile
    {
        public RelationsMapper()
        {
            
            CreateMap<Relations, RelationsReadDto>();
            CreateMap<RelationsReadDto, Relations>();            
            CreateMap<RelationsCreateDto, Relations>();   
            CreateMap<RelationsUpdateDto, Relations>();
        }
    }
}
