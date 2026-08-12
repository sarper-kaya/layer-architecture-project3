namespace proj1.Entity
{
    public class BaseEntity : IAuditEntity, ISoftDelete
    {
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateOnly CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Updatedby { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateOnly UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateOnly DeletedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
