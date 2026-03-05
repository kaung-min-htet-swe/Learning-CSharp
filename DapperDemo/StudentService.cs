using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperDemo;

public class StudentService
{
    private const string StudentTable = "Student";

    public Student RetriveById(SqlConnection conn, int id, bool includeContact = false)
    {
        var query = "";
        if (includeContact)
        {
            query = $"""
                      SELECT 
                          s.Id, s.Name, s.Age,
                          c.Id, c.Phone, c.Address
                     FROM dapperDb.dbo.Student s
                     LEFT JOIN  Contact c ON s.Id = c.StudentID
                     """;
            return conn.Query<Student, Contact, Student>(query, (student, contact) =>
            {
                student.Contact = contact;
                return student;
            }, splitOn: "Id").FirstOrDefault();
        }

        query = $"SELECT * FROM {StudentTable} WHERE Id = {id}";
        return conn.Query<Student>(query).FirstOrDefault();
    }
}