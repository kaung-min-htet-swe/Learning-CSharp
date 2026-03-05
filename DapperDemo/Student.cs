namespace DapperDemo;

public record struct Student
{
    public Student(string name)
    {
        Id = 0;
        Name = null;
        Age = 0;
        Major = null;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public List<Class> Classes { get; set; } = new List<Class>();
    public Major? Major { get; set; }
    public Contact Contact { get; set; }
}