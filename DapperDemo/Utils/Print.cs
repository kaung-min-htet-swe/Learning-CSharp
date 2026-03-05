namespace DapperDemo.Utils;

public class Print
{
    public static void Class(Class c, bool includeSubjects = false)
    {
        Console.WriteLine($"id: {c.Id} name: {c.Name} code: {c.ClassCode}");
    }

    public static void Subject(Subject subject, bool includeClass = false)
    {
        Console.WriteLine($"id: {subject.Id} name: {subject.Name}");
        if (includeClass)
        {
            Console.WriteLine("class:");
            var c = new Class()
            {
                Id = subject.ClassId,
                Name = subject.ClassName,
                ClassCode = subject.ClassCode,
            };
            Class(c);
        }
    }

    public static void Contact(Contact contact)
    {
        Console.WriteLine($"id: {contact.Id} phone: {contact.Phone} address: {contact.Address}");
    }

    public static void Student(Student student, bool includeContact = false)
    {
        Console.WriteLine($"id: {student.Id} name: {student.Name} age: {student.Age}");
        if (!includeContact) return;

        Console.WriteLine("contact:");
        Contact(student.Contact);
    }
}