using System;
using System.Collections.Generic;

namespace TestDI.Models.ContosoUniversity;

public partial class Course
{
    public int CourseId { get; set; }

    public string? Title { get; set; }

    public int Credits { get; set; }

    public int DepartmentId { get; set; }

    public string? Description { get; set; }

    public string? Slug { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime StartDate { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Person> Instructors { get; set; } = new List<Person>();
}
