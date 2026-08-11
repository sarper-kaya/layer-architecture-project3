using proj1.Entity;

namespace proj1.Dtos.FamiliyDtos
{
    public class FamilyUpdateDto
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public bool IsDeleted { get; set; }
        public DateOnly DelatedAt { get; set; }
        public int DeletedBy { get; set; }
        public ICollection<Person> Persons { get; set; } = new System.Collections.Generic.List<Person>();
    }
}
