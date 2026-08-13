using proj1.Entity;

namespace proj1.Dtos.BusinessDtos
{
    public class BusinessCreateDto : BaseDtoSoftDelete
    {
        
        public string? CompName { get; set; }
        public string? Occupation { get; set; }
        public bool IsWorking { get; set; }
         
         
         
        //public ICollection<Person> Persons { get; set; } = new System.Collections.Generic.List<Person>();

    }
}
