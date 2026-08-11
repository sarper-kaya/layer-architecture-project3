using Microsoft.AspNetCore.Mvc;
using proj1.Dtos.BusinessDtos;
using proj1.Entity;
using proj1.Service;
using proj1.Service.Business;

namespace proj1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _businessService;

        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> GetAll()
        {
            var list = await _businessService.GetAllAsync();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> Get(int id)
        {
            var business = await _businessService.GetByIdAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            return Ok(business);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BusinessCreateDto business)
        {
            var createdBusiness = await _businessService.CreateAsync(business);
            return CreatedAtAction(nameof(Get), new { id = createdBusiness.Id }, createdBusiness);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BusinessUpdateDto business)
        {
            var updatedBusiness = await _businessService.UpdateAsync(id, business);
            if (updatedBusiness == null)
            {
                return NotFound();
            }
            return Ok(updatedBusiness);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _businessService.DeleteAsync(id);
            return NoContent();
        }
    }

}
