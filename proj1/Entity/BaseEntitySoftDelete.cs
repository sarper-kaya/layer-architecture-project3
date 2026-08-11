namespace proj1.Entity
{
    public class BaseEntitySoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateOnly DeletedAt { get; set; }

    }
}
