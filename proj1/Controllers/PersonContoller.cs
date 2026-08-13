using Microsoft.AspNetCore.Mvc;
using proj1.Core;
using proj1.Dtos.PersonDtos;
using proj1.Entity;
using proj1.Service;
using proj1.Service.Person;

namespace proj1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonReadDto>>> GetAll()
        {
            var list = await _personService.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<PersonReadDto>>> GetById(int id)
        {
            var item = await _personService.GetByIdAsync(id);

            var response = new ServiceResult<PersonReadDto>(item.Data, item.Message, item.Success, item.StatusCode);

            return StatusCode(item.StatusCode, response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResult<PersonReadDto>>> Create([FromBody] PersonCreateDto personDto)
        {
            var created = await _personService.CreateAsync(personDto);
            var response = new ServiceResult<PersonReadDto>(created.Data, created.Message, created.Success, created.StatusCode);
            return StatusCode(created.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<PersonReadDto>>> Update(int id, [FromBody] PersonUpdateDto personDto)
        {
            var result = await _personService.UpdateAsync(id, personDto);
            var response = new ServiceResult<PersonReadDto>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<PersonReadDto>>> Delete(int id)
        {
            var result = await _personService.DeleteAsync(id);
            var response = new ServiceResult<PersonReadDto>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }



    }
}
