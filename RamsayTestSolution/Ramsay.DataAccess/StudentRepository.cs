using Ramsay.Models;
using Ramsay.Repositories;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

namespace Ramsay.DataAccess
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(string connectionString) : base(connectionString)
        {

        }

        public async Task<bool> DeleteStudent(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var sqlStatement = "DELETE Student WHERE Id = @Id";
                await connection.ExecuteAsync(sqlStatement, new { Id = id });
                return true;
            }
        }
    }
}
