using AutoMapper;
using proj1.Dtos.PersonDtos;
using proj1.Entity;

namespace proj1.Mappers
{
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {

            CreateMap<Person, PersonReadDto>();
            CreateMap<PersonReadDto, Person>();
            CreateMap<PersonCreateDto, Person>();
            CreateMap<PersonUpdateDto, Person>();
        }
    }
}

