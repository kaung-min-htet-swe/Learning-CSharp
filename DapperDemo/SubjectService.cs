using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperDemo;

public class SubjectService
{
    private const string SubjectTable = "Subject";

    public class Options
    {
        public bool IncludeClass = false;
    }

    public int Create(SqlConnection conn, Subject subject)
    {
        var query = $"""
                     INSERT INTO {SubjectTable} (Name) VALUES (@Name)
                     """;
        return conn.Execute(query, subject);
    }

    public List<Subject> ReadList(SqlConnection conn, Options? opts = null)
    {
        if (opts is { IncludeClass: true })
        {
            var sql = $"""
                       SELECT 
                           s.id AS Id,
                           s.name AS Name,
                           c.id AS ClassId,
                           c.name AS ClassName,
                           c.ClassCode AS ClassCode
                       FROM 
                           Subject s
                       LEFT JOIN
                           Class c ON s.ClassID = c.Id;
                       """;
            return conn.Query<Subject>(sql).ToList();
        }

        var query = $"SELECT * FROM dapperDb.dbo.Subject";
        List<Subject> subject = conn.Query<Subject>(query).ToList();
        return subject;
    }

    public Subject ReadById(SqlConnection conn, int id)
    {
        var query = $"SELECT * FROM {SubjectTable} WHERE Id = {id}";
        return conn.Query<Subject>(query).FirstOrDefault();
    }

    public int Delete(SqlConnection conn, int id)
    {
        var query = $"""
                     DELETE FROM {SubjectTable} WHERE Id = @Id
                     """;
        return conn.Execute(query, new { Id = id });
    }

    public int Delete(SqlConnection conn, Subject cond)
    {
        var query = new StringBuilder($"DELETE FROM {SubjectTable} WHERE 1=1");
        var parameters = new DynamicParameters();
        
        query.Append($" AND Name = @Name");
        parameters.Add("Name", cond.Name);
        
        return conn.Execute(query.ToString(), parameters);
    }
}