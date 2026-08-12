using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proj1.Entity
{
    public class Family : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Surname { get; set; }
        public ICollection<Person> Persons { get; set; } = new System.Collections.Generic.List<Person>();
       

    }
}
