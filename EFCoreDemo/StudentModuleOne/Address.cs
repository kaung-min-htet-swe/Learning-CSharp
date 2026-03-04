using EFCoreDemo.Shared;

namespace EFCoreDemo.StudentModule;

public class Address : Entity
{
    public string AddreLine { get; set; }
    public string Township { get; set; }
    public string State { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }
}