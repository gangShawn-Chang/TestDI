using System.Linq.Expressions;

namespace LearnIRepository.Interface
{
    /// <summary>
    /// 代表一個Repository的interface。
    /// </summary>
    /// <typeparam name="TContext">DbContext 的類型</typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// 取得第一筆符合條件的內容。如果符合條件有多筆，也只取得第一筆。
        /// </summary>
        /// <param name="predicate">要取得的Where條件。</param>
        /// <returns>取得第一筆符合條件的內容。</returns>
        Task<TEntity> GetSingleByIdAsync(int id);

        /// <summary>
        /// 取得Entity全部筆數的IQueryable。
        /// </summary>
        /// <returns>Entity全部筆數的IQueryable。</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// 新增一筆資料。
        /// </summary>
        /// <param name="entity">要新增到的Entity</param>
        Task CreateAsync(TEntity entity);

        /// <summary>
        /// 更新一筆資料的內容。
        /// </summary>
        /// <param name="entity">要更新的內容</param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// 刪除一筆資料內容。
        /// </summary>
        /// <param name="id">要被刪除的Entity的ID。</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// 儲存異動。
        /// </summary>
        Task<string> SaveChangesAsync();
    }
}
