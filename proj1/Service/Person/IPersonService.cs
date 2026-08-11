using proj1.Dtos.PersonDtos;

namespace proj1.Service.Person
{
    public interface IPersonService : IService<PersonReadDto, PersonCreateDto, PersonUpdateDto>
    {
        
    }
}
