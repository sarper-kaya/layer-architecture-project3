using Microsoft.AspNetCore.Mvc;
using proj1.Dtos.RelationsDtos;
using proj1.Entity;
using proj1.Service.Relations;

namespace proj1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelationsController : ControllerBase
    {
        private readonly IRelationsServices _relationsService;

        public RelationsController(IRelationsServices relationsService)
        {
            _relationsService = relationsService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relations>>> GetAll()
        {
            var list = await _relationsService.GetAllAsync();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Relations>> Get(int id)
        {
            var relations = await _relationsService.GetByIdAsync(id);
            if (relations == null)
            {
                return NotFound();
            }
            return Ok(relations);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RelationsCreateDto relations)
        {
            var createdRelations = await _relationsService.CreateAsync(relations);
            return CreatedAtAction(nameof(Get), new { id = createdRelations.Id }, createdRelations);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RelationsUpdateDto relations)
        {
            var updatedRelations = await _relationsService.UpdateAsync(id, relations);
            if (updatedRelations == null)
            {
                return NotFound();
            }
            return Ok(updatedRelations);
        }   
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _relationsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
