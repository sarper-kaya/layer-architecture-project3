using proj1.Entity;

namespace proj1.Core
{
    public static class SoftDelete
    {


        public static T MarkAsDeleted<T>(this T entity) where T : ISoftDelete
        {
            entity.IsDeleted = true;
            entity.DeletedAt = DateOnly.FromDateTime(DateTime.UtcNow);
            return entity;
        }
    }
}
