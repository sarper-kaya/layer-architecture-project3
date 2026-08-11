using proj1.Entity;

namespace proj1.Dtos.PersonDtos
{
    public class PersonUpdateDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public DateOnly Born { get; set; }
        public bool IsDeleted { get; set; }
        public DateOnly DelatedAt { get; set; }
        public int DeletedBy { get; set; }
    }
}
