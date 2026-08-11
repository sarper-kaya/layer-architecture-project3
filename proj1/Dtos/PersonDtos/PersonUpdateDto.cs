using proj1.Entity;

namespace proj1.Dtos.PersonDtos
{
    public class PersonUpdateDto : BaseDtoSoftDelete
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public DateOnly Born { get; set; }
         
         
         
    }
}
