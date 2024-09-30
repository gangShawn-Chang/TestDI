using Microsoft.EntityFrameworkCore;
using RepositoryLearn.Interface;
using RepositoryLearn.Models;

namespace RepositoryLearn.Repository
{
    public class Repository<Tcontext> : IRepository<Tcontext> where Tcontext : class
    {
        private readonly ContosoUniversityContext _dbContext;

        public Repository(ContosoUniversityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Tcontext>> GetAllAsync()
        {
            return await _dbContext.Set<Tcontext>().ToListAsync();
        }

        public async Task<Tcontext> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Tcontext>().FindAsync(id);
        }

        public async Task AddAsync(Tcontext tcontext)
        {
            await _dbContext.Set<Tcontext>().AddAsync(tcontext);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(Tcontext tcontext)
        {
            _dbContext.Set<Tcontext>().Update(tcontext);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<Tcontext>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<Tcontext>().Remove(entity);
                await SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
