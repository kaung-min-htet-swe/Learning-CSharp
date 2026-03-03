namespace EFCoreTutorial;

public class Student
{
    public int StudendID { get; set; }
    public string StudentName { get; set; }
    public DateTime? DateOfBirth { get; set;  }
    public decimal Height { get; set; }
    public float Weight { get; set; }

    public Grade Grade { get; set; }
}

