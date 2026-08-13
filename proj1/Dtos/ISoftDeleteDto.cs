namespace proj1.Dtos
{
    public interface ISoftDeleteDto
    {
        bool IsDeleted { get; set; }
        DateOnly DeletedAt { get; set; }
    }
}

