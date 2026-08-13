using proj1.Dtos.PersonDtos;
using proj1.Entity;

namespace proj1.Dtos.FamiliyDtos
{
    public class FamilyCreateDto : BaseDtoSoftDelete
    {
        
        public string? Surname { get; set; }
         
         
         
        //public ICollection<PersonReadDto> Persons { get; set; } = new System.Collections.Generic.List<PersonReadDto>();
    }
}
