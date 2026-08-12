namespace proj1.Entity
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateOnly DeletedAt { get; set; }
    }
}
