using proj1.Entity;

namespace proj1.Dtos.RelationsDtos
{
    public class RelationsCreateDto : BaseDtoSoftDelete
    {
        
        public int RelationsWithId { get; set; }
        public RelationStatus Relation { get; set; }
        public int MainPersonId { get; set; }
        //public Person? Person { get; set; }
        public int RelationsWith { get; set; }
         
         
         
    }
}
