namespace DapperDemo;

public record struct Contact
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public int StudentId { get; set; }
}