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
            var markedNewPerson = SoftDelete.MarkAsNewRecord(newPerson);
            markedNewPerson = AuditEntityManagement.NewRecord(markedNewPerson);
            var savedPerson = await _personRepository.AddAsync(markedNewPerson);
            if (savedPerson == null)
            {
                return ServiceResult<PersonReadDto>.FailResult("Failed to create person", StatusCodes.Status500InternalServerError);
            }
            return ServiceResult<PersonReadDto>.SuccessResult(_mapper.Map<PersonReadDto>(savedPerson));
        }


        public async Task<ServiceResult<PersonReadDto>> UpdateAsync(int id, PersonUpdateDto dto)
        {
            var entity = await _personRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return ServiceResult<PersonReadDto>.FailResult("Person not found", StatusCodes.Status404NotFound);
            }

            _mapper.Map(dto, entity);
            entity = AuditEntityManagement.UpdateRecord(entity);
            var updatedEntity = await _personRepository.Update(entity);
            return ServiceResult<PersonReadDto>.SuccessResult(_mapper.Map<PersonReadDto>(updatedEntity));

        }

        public async Task<ServiceResult<PersonReadDto>> DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person == null)
            {
                return ServiceResult<PersonReadDto>.FailResult("Person not found", StatusCodes.Status404NotFound);
            }
            else
            {
                person = AuditEntityManagement.UpdateRecord(person);
                person = SoftDelete.MarkAsDeleted(person);
                var markedAsDeletedPerson = await _personRepository.Update(person);
                return ServiceResult<PersonReadDto>.SuccessResult(_mapper.Map<PersonReadDto>(markedAsDeletedPerson));
            }



        }


    }
}
