using AutoMapper;
using proj1.Core;
using proj1.Dtos.PersonDtos;
using proj1.Entity;
using proj1.Repos;
using proj1.Repos.PersonRepos;
namespace proj1.Service.Person
{
    public class PersonServices : IPersonService
    {
        private readonly IPersonRepo _personRepository;
        private readonly IMapper _mapper;
        public PersonServices(IPersonRepo personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<PersonReadDto>>> GetAllAsync()
        {
            var persons = await _personRepository.GetAllAsync();

            return ServiceResult<IEnumerable<PersonReadDto>>.SuccessResult(_mapper.Map<IEnumerable<PersonReadDto>>(persons));
        }


        public async Task<ServiceResult<PersonReadDto>> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                return ServiceResult<PersonReadDto>.FailResult("Person not found", StatusCodes.Status404NotFound);
            }

            var dto = _mapper.Map<PersonReadDto>(person);
            return ServiceResult<PersonReadDto>.SuccessResult(dto);
        }

        public async Task<ServiceResult<PersonReadDto>> CreateAsync(PersonCreateDto personDto)
        {
            var newPerson = _mapper.Map<Entity.Person>(personDto);
            var savedPerson = await _personRepository.AddAsync(newPerson);
            if (savedPerson == null) 
            { 
                return ServiceResult<PersonReadDto>.FailResult("Failed to create person", StatusCodes.Status500InternalServerError);
            }
            return ServiceResult<PersonReadDto>.SuccessResult(_mapper.Map<PersonReadDto>(savedPerson));
        }


        public async Task<ServiceResult<bool>> UpdateAsync(int id, PersonUpdateDto dto)
        {
            var entity = await _personRepository.GetByIdAsync(id);
            if (entity is null) return ServiceResult<bool>.FailResult("Person not found", StatusCodes.Status404NotFound);

            _mapper.Map(dto, entity);
            //return await _personRepository.Update(entity);
            return ServiceResult<bool>.SuccessResult(true);
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null) return ServiceResult<bool>.FailResult("Person not found", StatusCodes.Status404NotFound);

            //return await _personRepository.Delete(person);
            return ServiceResult<bool>.SuccessResult(true);
        }

    
    }
}
