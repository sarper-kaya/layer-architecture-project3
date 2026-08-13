using Microsoft.AspNetCore.Mvc;
using proj1.Core;
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
        public async Task<ActionResult<ServiceResult<IEnumerable<BusinessReadDto>>>> GetAll()
        {
            var result = await _businessService.GetAllAsync();
            var response = new ServiceResult<IEnumerable<BusinessReadDto>>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<BusinessReadDto>>> Get(int id)
        {
            var result = await _businessService.GetByIdAsync(id);
            var response = new ServiceResult<BusinessReadDto>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<BusinessReadDto>>> Post([FromBody] BusinessCreateDto business)
        {
            var result = await _businessService.CreateAsync(business);
            var response = new ServiceResult<BusinessReadDto>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<BusinessReadDto>>> Put(int id, [FromBody] BusinessUpdateDto business)
        {
            var result = await _businessService.UpdateAsync(id, business);
            var response = new ServiceResult<BusinessReadDto>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<BusinessReadDto>>> Delete(int id)
        {
            var result = await _businessService.DeleteAsync(id);
            var response = new ServiceResult<BusinessReadDto>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }
    }

}
