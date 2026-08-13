using AutoMapper;
using proj1.Core;
using proj1.Dtos.FamiliyDtos;
using proj1.Repos;
using proj1.Repos.FamilyRepos;

namespace proj1.Service.Family
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepo _familyRepository;
        public readonly IMapper _mapper;

        public FamilyService(IFamilyRepo familyRepository, IMapper mapper)
        {
            _familyRepository = familyRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<FamilyReadDto>>> GetAllAsync()
        {
            var families = await _familyRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<FamilyReadDto>>(families);
            return ServiceResult<IEnumerable<FamilyReadDto>>.SuccessResult(dtos);
        }

        public async Task<ServiceResult<FamilyReadDto>> GetByIdAsync(int id)
        {
            var family = await _familyRepository.GetByIdAsync(id);
            if (family == null)
            {
                return ServiceResult<FamilyReadDto>.FailResult("Family not found", StatusCodes.Status404NotFound);
            }

            var dto = _mapper.Map<FamilyReadDto>(family);
            return ServiceResult<FamilyReadDto>.SuccessResult(dto);
        }

        public async Task<ServiceResult<FamilyReadDto>> CreateAsync(FamilyCreateDto familyDto)
        {
            var newFamily = _mapper.Map<Entity.Family>(familyDto);
            newFamily = AuditEntityManagement.NewRecord(newFamily);
            var savedFamily = await _familyRepository.AddAsync(SoftDelete.MarkAsNewRecord(newFamily));
            var dto = _mapper.Map<FamilyReadDto>(savedFamily);
            return ServiceResult<FamilyReadDto>.SuccessResult(dto, StatusCodes.Status201Created);
        }

        public async Task<ServiceResult<FamilyReadDto>> UpdateAsync(int id, FamilyUpdateDto familyDto)
        {
            var family = await _familyRepository.GetByIdAsync(id);
            if (family == null)
            {
                return ServiceResult<FamilyReadDto>.FailResult("Family not found", StatusCodes.Status404NotFound);
            }   

            _mapper.Map(familyDto, family);
            family = AuditEntityManagement.UpdateRecord(family);
            var updatedFamily = await _familyRepository.Update(family);
            return ServiceResult<FamilyReadDto>.SuccessResult(_mapper.Map<FamilyReadDto>(updatedFamily));
        }

        public async Task<ServiceResult<FamilyReadDto>> DeleteAsync(int id)
        {
            var family = await _familyRepository.GetByIdAsync(id);
            if (family == null)
            {
                return ServiceResult<FamilyReadDto>.FailResult("Family not found", StatusCodes.Status404NotFound);
            }

            family = AuditEntityManagement.UpdateRecord(family);
            family = SoftDelete.MarkAsDeleted(family);
            var markedAsDeletedFamily = await _familyRepository.Update(family);

            return ServiceResult<FamilyReadDto>.SuccessResult(_mapper.Map<FamilyReadDto>(markedAsDeletedFamily));
        }


    }
}
