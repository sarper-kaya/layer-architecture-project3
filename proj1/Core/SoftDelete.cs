using proj1.Entity;

namespace proj1.Core
{
    public class SoftDelete<T>:BaseEntitySoftDelete
    {
        public T dbDeletion(T entity)
        {
            //entity.IsDeleted = true;
            return entity;
        }
    }
}
