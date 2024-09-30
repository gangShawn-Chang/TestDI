using LearnIRepository.Interface;
using LearnIRepository.Models.ContosoUniversity;
using LearnIRepository.Models.NorthWind;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LearnIRepository.EFGenericRepository
{


    /// <summary>
    /// 實作Entity Framework Generic Repository 的 Class。
    /// </summary>
    /// <typeparam name="TEntity">EF Model 裡面的Type</typeparam>
    /// <typeparam name="TContext">DbContext 的類型</typeparam>
    public class EFGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly NorthWindContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EFGenericRepository(NorthWindContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetSingleByIdAsync(int id)
        {

            return await _dbSet.FindAsync(id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public Task<string> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }

}
