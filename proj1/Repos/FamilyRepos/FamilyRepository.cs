using Microsoft.EntityFrameworkCore;
using proj1.Data;
using proj1.Entity;

namespace proj1.Repos.FamilyRepos
{
    public class FamilyRepository:IFamilyRepo
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Family> _dbSet;

        public FamilyRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Family>();
        }

        public async Task<Family?> AddAsync(Family entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<Family>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Family?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Family?> Update(Family entity)
        {
            var entry = _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Family?> Delete(Family entity)
        {
            var entry = _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
