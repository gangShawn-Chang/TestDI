using RepositoryLearn.Interface;
using RepositoryLearn.Models;

namespace RepositoryLearn.Services
{
    public interface ICourseServices
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCoursesByIdAsync(int id);
        Task AddCoursesAsync(Course product);
        Task UpdateCoursesAsync(Course product);
        Task DeleteProductAsync(int id);
        Task SaveChangesAsync();
    }

    public class CoursesService : ICourseServices
    {
        private readonly IRepository<Course> _repository;

        public CoursesService(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Course> GetCoursesByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddCoursesAsync(Course course)
        {

            await _repository.AddAsync(course);
        }

        public async Task UpdateCoursesAsync(Course course)
        {
            await _repository.UpdateAsync(course);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
    }
}
