using proj1.Dtos.RelationsDtos;
using proj1.Entity;

namespace proj1.Dtos.PersonDtos
{
    public class PersonReadDto : BaseDtoSoftDelete
    {
        public int Id { get; set; }
        public int FamilyId { get; set; }
        //public Family Family { get; set; } = null!; // required olabilir
        public int BusinessId { get; set; }
        //public Business? Business { get; set; }
        public ICollection<RelationsReadDto> Relations { get; set; } = new List<RelationsReadDto>();
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public DateOnly Born { get; set; }
         
    }
}
