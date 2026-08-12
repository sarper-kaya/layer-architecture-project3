using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proj1.Entity
{
    public class Relations : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RelationsWithId { get; set; }
        public RelationStatus Relation { get; set; }
        public int MainPersonId { get; set; }
        public Person? Person { get; set; }
        public int RelationsWith { get; set; }
        



    }
    public enum RelationStatus
    {
        Father,
        Mother,
        Child,
        Friend,
        Partner

    }
}
