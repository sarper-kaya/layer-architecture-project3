using proj1.Entity;

namespace proj1.Dtos.BusinessDtos
{
    public class BusinessReadDto : BaseDtoSoftDelete
    {
        public int Id { get; set; }
        public string? CompName { get; set; }
        public string? Occupation { get; set; }
        public bool IsWorking { get; set; }
         
         
         
        public ICollection<Person> Persons { get; set; } = new System.Collections.Generic.List<Person>();

    }
}
