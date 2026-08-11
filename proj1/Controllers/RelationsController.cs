using Microsoft.AspNetCore.Mvc;
using proj1.Dtos.CustomResponseDtos;
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
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<RelationsReadDto>>>> GetAll()
        {
            var result = await _relationsService.GetAllAsync();
            var response = new ApiResponse<IEnumerable<RelationsReadDto>>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<RelationsReadDto>>> Get(int id)
        {
            var result = await _relationsService.GetByIdAsync(id);
            var response = new ApiResponse<RelationsReadDto>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<RelationsReadDto>>> Post([FromBody] RelationsCreateDto relations)
        {
            var result = await _relationsService.CreateAsync(relations);
            var response = new ApiResponse<RelationsReadDto>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Put(int id, [FromBody] RelationsUpdateDto relations)
        {
            var result = await _relationsService.UpdateAsync(id, relations);
            var response = new ApiResponse<bool>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(int id)
        {
            var result = await _relationsService.DeleteAsync(id);
            var response = new ApiResponse<bool>(result.Data, result.Message, result.Success, result.StatusCode);
            return StatusCode(result.StatusCode, response);
        }
    }
}
