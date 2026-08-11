using proj1.Dtos.BusinessDtos;

namespace proj1.Service.Business
{
    public interface IBusinessService : IService<BusinessReadDto, BusinessCreateDto, BusinessUpdateDto>
    {
    }
}
