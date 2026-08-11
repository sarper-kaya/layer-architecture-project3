using AutoMapper;
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

        public async Task<RelationsReadDto> CreateAsync(RelationsCreateDto relationDto)
        {
            var newRelation = _mapper.Map<Entity.Relations>(relationDto);
            var savedRelation = await _relationsRepository.AddAsync(newRelation);
            return _mapper.Map<RelationsReadDto>(savedRelation);
        }

        

        public async Task<IEnumerable<RelationsReadDto>> GetAllAsync()
        {
            var relations = await _relationsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RelationsReadDto>>(relations);
        }

        public async Task<RelationsReadDto?> GetByIdAsync(int id)
        {
            var relation = await _relationsRepository.GetByIdAsync(id);
            return _mapper.Map<RelationsReadDto?>(relation);
        }

        public async Task<bool> UpdateAsync(int id, RelationsUpdateDto personDto)
        {
            var relation = _relationsRepository.GetByIdAsync(id).Result;
            if (relation == null) throw new ArgumentException("Relation not found");
            _mapper.Map(personDto, relation);
            await _relationsRepository.Update(relation);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var relation = await _relationsRepository.GetByIdAsync(id);
            if (relation == null) throw new ArgumentException("Relation not found");
            await _relationsRepository.Delete(relation);
            return true;
        }
    }
}
