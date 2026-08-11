using proj1.Entity;

namespace proj1.Dtos.FamiliyDtos
{
    public class FamilyCreateDto : BaseDtoSoftDelete
    {
        
        public string? Surname { get; set; }
         
         
         
        public ICollection<Person> Persons { get; set; } = new System.Collections.Generic.List<Person>();
    }
}
