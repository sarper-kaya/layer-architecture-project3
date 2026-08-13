using proj1.Entity;

namespace proj1.Core
{
    public class AuditEntityManagement
    {
        public static T NewRecord<T>(T entity) where T : IAuditEntity
        {
            entity.CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
            entity.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
            return entity;
        }


        public static T UpdateRecord<T>(T entity) where T : IAuditEntity
        {
            entity.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
            return entity;
        }
    }
}
