using EFCore.DataAccess;

namespace EFCore;

public class Enrollment : Base
{
    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
}