using AutoMapper;
using proj1.Dtos.PersonDtos;
using proj1.Entity;
using proj1.Repos;
namespace proj1.Service.Person
{
    public class PersonServices : IPersonService
    {
        private readonly IRepos<Entity.Person> _personRepository;
        private readonly IMapper _mapper;
        public PersonServices(IRepos<Entity.Person> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonReadDto>> GetAllAsync()
        {
            var persons = await _personRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonReadDto>>(persons);
        }


        public async Task<PersonReadDto?> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            return _mapper.Map<PersonReadDto?>(person);
        }

        public async Task<PersonReadDto> CreateAsync(PersonCreateDto personDto)
        {
            var newPerson = _mapper.Map<Entity.Person>(personDto);
            var savedPerson = await _personRepository.AddAsync(newPerson);
            return _mapper.Map<PersonReadDto>(savedPerson);
        }


        public async Task<bool> UpdateAsync(int id, PersonUpdateDto dto)
        {
            var entity = await _personRepository.GetByIdAsync(id);
            if (entity is null) return false;

            _mapper.Map(dto, entity);
            //return await _personRepository.Update(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null) throw new ArgumentException("Person not found");


            //return await _personRepository.Delete(person);
            return true;
        }
    }
}
