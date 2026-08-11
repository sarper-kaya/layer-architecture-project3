using Microsoft.AspNetCore.Mvc;
using proj1.Dtos.BusinessDtos;
using proj1.Dtos.FamiliyDtos;
using proj1.Entity;
using proj1.Service.Family;

namespace proj1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyContoller : ControllerBase
    {
        private readonly IFamilyService _familyService;
        public FamilyContoller(IFamilyService familyService)
        {
            _familyService = familyService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Family>>> GetAll()
        {
            var list = await _familyService.GetAllAsync();
            
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Family>> Get(int id)
        {
            var family = await _familyService.GetByIdAsync(id);
            
            return Ok(family);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FamilyCreateDto family)
        {
            var createdFamily = await _familyService.CreateAsync(family);
            return CreatedAtAction(nameof(Get), new { id = createdFamily.Id }, createdFamily);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FamilyUpdateDto family)
        {
            var updatedFamily = await _familyService.UpdateAsync(id, family);
            if (updatedFamily == null)
            {
                return NotFound();
            }
            return Ok(updatedFamily);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _familyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
