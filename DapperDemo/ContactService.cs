using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperDemo;

public class ContactService
{
    private const string ContactTable = "Contact";

    public int Create(SqlConnection conn, Contact contact)
    {
        var query = $"""
            INSERT INTO {ContactTable} (Phone, Address, StudentID) VALUES (@Phone, @Address, @StudentId)
        """;
        return conn.Execute(query, contact);
    }
}