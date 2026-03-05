namespace EFCore.DataAccess;

public class Course:Base
{
    public string CourseName { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}