using proj1.Entity;

namespace proj1.Dtos
{
    public class BaseDtoSoftDelete : IAuditDto,ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateOnly DeletedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateOnly CreatedAt { get; set; }
        public string Updatedby { get; set; }
        public DateOnly UpdatedAt { get; set; }
    }
}
