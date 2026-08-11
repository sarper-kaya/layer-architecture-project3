using AutoMapper;
using proj1.Core;
using proj1.Dtos.RelationsDtos;
using proj1.Repos;

namespace proj1.Service.Relations
{
    public class RelationsServices : IRelationsServices
    {
        private readonly IRepos<Entity.Relations> _relationsRepository;
        private readonly IMapper _mapper;

        public RelationsServices(IRepos<Entity.Relations> relationsRepository, IMapper mapper)
        {
            _relationsRepository = relationsRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<RelationsReadDto>> CreateAsync(RelationsCreateDto relationDto)
        {
            var newRelation = _mapper.Map<Entity.Relations>(relationDto);
            var savedRelation = await _relationsRepository.AddAsync(newRelation);
            var dto = _mapper.Map<RelationsReadDto>(savedRelation);
            return ServiceResult<RelationsReadDto>.SuccessResult(dto, StatusCodes.Status201Created);
        }

        public async Task<ServiceResult<IEnumerable<RelationsReadDto>>> GetAllAsync()
        {
            var relations = await _relationsRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<RelationsReadDto>>(relations);
            return ServiceResult<IEnumerable<RelationsReadDto>>.SuccessResult(dtos);
        }

        public async Task<ServiceResult<RelationsReadDto>> GetByIdAsync(int id)
        {
            var relation = await _relationsRepository.GetByIdAsync(id);
            if (relation == null)
            {
                return ServiceResult<RelationsReadDto>.FailResult("Relation not found", StatusCodes.Status404NotFound);
            }

            var dto = _mapper.Map<RelationsReadDto>(relation);
            return ServiceResult<RelationsReadDto>.SuccessResult(dto);
        }

        public async Task<ServiceResult<bool>> UpdateAsync(int id, RelationsUpdateDto relationDto)
        {
            var relation = await _relationsRepository.GetByIdAsync(id);
            if (relation == null)
            {
                return ServiceResult<bool>.FailResult("Relation not found", StatusCodes.Status404NotFound);
            }

            _mapper.Map(relationDto, relation);
            await _relationsRepository.Update(relation);
            return ServiceResult<bool>.SuccessResult(true);
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var relation = await _relationsRepository.GetByIdAsync(id);
            if (relation == null)
            {
                return ServiceResult<bool>.FailResult("Relation not found", StatusCodes.Status404NotFound);
            }

            await _relationsRepository.Delete(relation);
            return ServiceResult<bool>.SuccessResult(true);
        }
    }
}
