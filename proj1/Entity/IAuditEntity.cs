namespace proj1.Entity
{
    public interface IAuditEntity
    {
        string CreatedBy { get; set; }
        DateOnly CreatedAt { get; set; }
        string Updatedby { get; set; }
        DateOnly UpdatedAt { get; set; }
    }
}
