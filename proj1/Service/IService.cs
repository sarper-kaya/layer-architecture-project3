using proj1.Core;
using proj1.Entity;

namespace proj1.Service
{
    public interface IService<TReadDto, TCreateDto, TUpdateDto>
    {


        Task<ServiceResult<IEnumerable<TReadDto>>> GetAllAsync();
        Task<ServiceResult<TReadDto>> GetByIdAsync(int id);
        Task<ServiceResult<TReadDto>> CreateAsync(TCreateDto dto);
        Task<ServiceResult<TReadDto>> UpdateAsync(int id, TUpdateDto dto);
        Task<ServiceResult<TReadDto>> DeleteAsync(int id);


    }
}
