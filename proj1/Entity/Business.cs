
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proj1.Entity
{
    public class Business : BaseEntitySoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CompName { get; set; }
        public string? Occupation   { get; set; }
        public bool IsWorking { get; set; }
        public ICollection<Person> Persons { get; set; } = new System.Collections.Generic.List<Person>();


    }
}
