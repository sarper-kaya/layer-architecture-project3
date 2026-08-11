using Microsoft.EntityFrameworkCore;
using proj1.Data;

namespace proj1.Repos
{
    public class Repository<T> : IRepos<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        
        public async Task<T> AddAsync(T entity)
        {
            var entry = await _dbSet.AddAsync(entity);//burada ne yaptigini anladim nasil yaptigini anlamadim
            return entry.Entity; // Veritabanı ID'si (varsa) ve güncel haliyle döner
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return entity;
        }//supheli silinmisd bir seyin nesnesinin donmesi mumkun degil

       

    }
}
