using Microsoft.EntityFrameworkCore;
using proj1.Data;
using proj1.Entity;

namespace proj1.Repos.RelationsRepos
{
    public class RelationsRepository: IRelationsRepo
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Relations> _dbSet;

        public RelationsRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Relations>();
        }

        public async Task<Relations?> AddAsync(Relations entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<Relations>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Relations?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Relations?> Update(Relations entity)
        {
            var entry = _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Relations?> Delete(Relations entity)
        {
            var entry = _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
