using Microsoft.EntityFrameworkCore;
using proj1.Data;
using proj1.Entity;

namespace proj1.Repos.BusinessRepos
{
    public class BusinessRepository : IBusinessRepo
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Business> _dbSet;

        public BusinessRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Business>();
        }

        public async Task<Business?> AddAsync(Business entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<Business>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Business?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Business?> Update(Business entity)
        {
            var entry = _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Business?> Delete(Business entity)
        {
            var entry = _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}

