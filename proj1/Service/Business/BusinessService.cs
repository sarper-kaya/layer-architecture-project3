using AutoMapper;
using proj1.Core;
using proj1.Dtos.BusinessDtos;

using proj1.Repos.BusinessRepos;

namespace proj1.Service.Business
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepo _businessRepository;
        private readonly IMapper _mapper;

        public BusinessService(IBusinessRepo businessRepository, IMapper mapper)
        {
            _businessRepository = businessRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<BusinessReadDto>> CreateAsync(BusinessCreateDto businessDto)
        {
            var newBusiness = _mapper.Map<Entity.Business>(businessDto);
            var savedBusiness = await _businessRepository.AddAsync(newBusiness);
            var dto = _mapper.Map<BusinessReadDto>(savedBusiness);
            return ServiceResult<BusinessReadDto>.SuccessResult(dto, StatusCodes.Status201Created);
        }
        public async Task<ServiceResult<IEnumerable<BusinessReadDto>>> GetAllAsync()
        {
            var businesses = await _businessRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<BusinessReadDto>>(businesses);
            return ServiceResult<IEnumerable<BusinessReadDto>>.SuccessResult(dtos);
        }

        public async Task<ServiceResult<BusinessReadDto>> GetByIdAsync(int id)
        {
            var business = await _businessRepository.GetByIdAsync(id);
            if (business == null)
            {
                return ServiceResult<BusinessReadDto>.FailResult("Business not found", StatusCodes.Status404NotFound);
            }

            var dto = _mapper.Map<BusinessReadDto>(business);
            return ServiceResult<BusinessReadDto>.SuccessResult(dto);
        }

        public async Task<ServiceResult<bool>> UpdateAsync(int id, BusinessUpdateDto businessDto)
        {
            var business = await _businessRepository.GetByIdAsync(id);
            if (business == null)
            {
                return ServiceResult<bool>.FailResult("Business not found", StatusCodes.Status404NotFound);
            }

            _mapper.Map(businessDto, business);
            await _businessRepository.Update(business);
            return ServiceResult<bool>.SuccessResult(true);
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var business = await _businessRepository.GetByIdAsync(id);
            if (business == null)
            {
                return ServiceResult<bool>.FailResult("Business not found", StatusCodes.Status404NotFound);
            }

            //await _businessRepository.Delete(business);
            return ServiceResult<bool>.SuccessResult(true);
        }
    }
}
