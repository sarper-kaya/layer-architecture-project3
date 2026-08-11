using Microsoft.AspNetCore.Mvc;
using proj1.Dtos.BusinessDtos;
using proj1.Dtos.CustomResponseDtos;
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
        public async Task<ActionResult<ApiResponse<IEnumerable<FamilyReadDto>>>> GetAll()
        {
            var result = await _familyService.GetAllAsync();
            var response = new ApiResponse<IEnumerable<FamilyReadDto>>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<FamilyReadDto>>> Get(int id)
        {
            var result = await _familyService.GetByIdAsync(id);
            var response = new ApiResponse<FamilyReadDto>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<FamilyReadDto>>> Post([FromBody] FamilyCreateDto family)
        {
            var result = await _familyService.CreateAsync(family);
            var response = new ApiResponse<FamilyReadDto>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Put(int id, [FromBody] FamilyUpdateDto family)
        {
            var result = await _familyService.UpdateAsync(id, family);
            var response = new ApiResponse<bool>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            var result = await _familyService.DeleteAsync(id);
            var response = new ApiResponse<bool>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }
    }
}
