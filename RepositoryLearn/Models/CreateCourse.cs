using System.ComponentModel.DataAnnotations;
#nullable disable
namespace RepositoryLearn.Models
{
    public class CreateCourse
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Slug { get; set; }

    }
}
