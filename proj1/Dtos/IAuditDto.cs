namespace proj1.Dtos
{
    public interface IAuditDto
    {
        string CreatedBy { get; set; }
        DateOnly CreatedAt { get; set; }
        string Updatedby { get; set; }
        DateOnly UpdatedAt { get; set; }
    }
}
