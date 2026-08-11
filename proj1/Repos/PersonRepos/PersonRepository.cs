using Microsoft.EntityFrameworkCore;
using proj1.Data;
using proj1.Entity;

namespace proj1.Repos.PersonRepos
{
    public class PersonRepository:IPersonRepo
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Person> _dbSet;
        public PersonRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Person>();
        }
        public async Task<Person?> AddAsync(Person entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity; 

        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Person?> Update(Person entity)
        {
            var entry = _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Person?> Delete(Person entity)
        {
            var entry = _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
