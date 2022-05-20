using Ramsay.Models;
using Ramsay.Repositories;

namespace Ramsay.DataAccess
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
