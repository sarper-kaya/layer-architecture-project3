using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<PersonReadDto>> GetById(int id)
        {
            var item = await _personService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<PersonReadDto>> Create([FromBody] PersonCreateDto personDto)
        {
            var created = await _personService.CreateAsync(personDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonUpdateDto personDto)
        {
            var result = await _personService.UpdateAsync(id, personDto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personService.DeleteAsync(id); 
            if (!result) return NotFound();
            
            return NoContent();
        }



    }
}
