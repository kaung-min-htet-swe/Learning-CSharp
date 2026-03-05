using DapperDemo;
using DapperDemo.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

var connectionString =
    "Server=localhost;Database=dapperDb;User ID=sa;Password=DataC0Ntr0ll3r;Encrypt=True;TrustServerCertificate=True;";
using var connection = new SqlConnection(connectionString);
Console.WriteLine($"database: {connection.Database}");

var subjectService = new SubjectService();
var studentService = new StudentService();
var contactService = new ContactService();
contactService.Create(connection, new Contact()
{
    Address = "YanKin",
    Phone = "123456789",
    StudentId = 1,
});
Student student = studentService.RetriveById(connection, 1, true);
Print.Student(student!, true);

// var contact = new Contact()
// {
//     Address = "YanKin",
//     Phone = "123456789",
//     StudentId = 1,
// };
//
// var contactService = new ContactService();
// var result = contactService.Create(connection, contact);
// if (result > 0)
// {
//     Console.WriteLine("Success to create");
// }
// else
// {
//     Console.WriteLine("Failed to create");
// }


// var opts = new SubjectService.Options()
// {
//     IncludeClass = false,
// };
//
// var english = new Subject()
// {
//     Name = "English"
// };
// subjectService.Create(connection, english);
// var result = subjectService.Delete(connection, new Subject()
// {
//     Name = "English",
// });
// if (result == 0)
// {
//     Console.WriteLine("Fail to delete");
// }

// var result = subjectService.Create(connection, english);
// if (result == 0)
// {
//     Console.WriteLine("Fail to create");
// }
// else
// {
// var subjects = subjectService.ReadList(connection);
// foreach (var subject in subjects)
// {
//     Print.Subject(subject, false);
// }
// }