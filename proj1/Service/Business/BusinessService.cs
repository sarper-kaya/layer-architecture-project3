using AutoMapper;
using proj1.Dtos.BusinessDtos;
using proj1.Repos;

namespace proj1.Service.Business
{
    public class BusinessService : IBusinessService
    {
        private readonly IRepos<Entity.Business> _businessRepository;
        private readonly IMapper _mapper;

        public BusinessService(IRepos<Entity.Business> businessRepository, IMapper mapper)
        {
            _businessRepository = businessRepository;
            _mapper = mapper;
        }

        public async Task<BusinessReadDto> CreateAsync(BusinessCreateDto businessDto)
        {
            var newBusiness = _mapper.Map<Entity.Business>(businessDto);
            var savedBusiness = await _businessRepository.AddAsync(newBusiness);
            return _mapper.Map<BusinessReadDto>(savedBusiness);
        }

        

        public async Task<IEnumerable<BusinessReadDto>> GetAllAsync()
        {
            var businesses = await _businessRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BusinessReadDto>>(businesses);
        }


        public async Task<BusinessReadDto?> GetByIdAsync(int id)
        {
            var business = await _businessRepository.GetByIdAsync(id);
            return _mapper.Map<BusinessReadDto?>(business);
        }

        public async Task<bool> UpdateAsync(int id, BusinessUpdateDto personDto)
        {
            var business = await _businessRepository.GetByIdAsync(id);
            if (business == null) throw new ArgumentException("Business not found");
            _mapper.Map(personDto, business);
            await _businessRepository.Update(business);
            //return _mapper.Map<BusinessReadDto?>(business);
                        return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var business = await _businessRepository.GetByIdAsync(id);
            if (business == null) throw new ArgumentException("Business not found");
           // await _businessRepository.Delete(business);
            return true;
        }
    }
}
