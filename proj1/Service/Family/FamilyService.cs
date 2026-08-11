using AutoMapper;
using proj1.Dtos.FamiliyDtos;
using proj1.Repos;

namespace proj1.Service.Family
{
    public class FamilyService : IFamilyService
    {
        private readonly IRepos<Entity.Family> _familyRepository;

        public readonly IMapper _mapper;
        public FamilyService(IRepos<Entity.Family> familyRepository, IMapper mapper)
        {
            _familyRepository = familyRepository;

            _mapper = mapper;
        }
        public async Task<IEnumerable<FamilyReadDto>> GetAllAsync()
        {
            var families = await _familyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FamilyReadDto>>(families);
        }

        public async Task<FamilyReadDto?> GetByIdAsync(int id)
        {
            var family = await _familyRepository.GetByIdAsync(id);
            return _mapper.Map<FamilyReadDto>(family);
        }

        public async Task<FamilyReadDto> CreateAsync(FamilyCreateDto familyDto)
        {
            var newFamily = _mapper.Map<Entity.Family>(familyDto);
            var savedFamily = await _familyRepository.AddAsync(newFamily);
            return _mapper.Map<FamilyReadDto>(savedFamily);
        }

        public async Task<bool> UpdateAsync(int id, FamilyUpdateDto familyDto)
        {
            var family = await _familyRepository.GetByIdAsync(id);
            if (family == null) throw new ArgumentException("Family not found"); ;

            _mapper.Map(familyDto, family);
            await _familyRepository.Update(family);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var family = await _familyRepository.GetByIdAsync(id);
            if (family == null) throw new ArgumentException("Family not found"); ;

            await _familyRepository.Delete(family);
            return true;
        }


    }
}
