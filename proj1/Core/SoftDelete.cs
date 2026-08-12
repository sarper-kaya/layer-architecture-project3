using proj1.Entity;

namespace proj1.Core
{
    public static class SoftDelete<T> where T : ISoftDelete
    {


        public static T dbDeletion(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedAt = DateOnly.FromDateTime(DateTime.UtcNow);
            return entity;
        }
    }
}
