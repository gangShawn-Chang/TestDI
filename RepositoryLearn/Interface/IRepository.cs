namespace RepositoryLearn.Interface
{
    public interface IRepository<Tcontext> where Tcontext : class
    {
        Task<IEnumerable<Tcontext>> GetAllAsync();
        Task<Tcontext> GetByIdAsync(int id);
        Task AddAsync(Tcontext tcontext);
        Task UpdateAsync(Tcontext tcontext);
        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}
