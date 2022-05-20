using Ramsay.Repositories;
using Ramsay.UnitOfWork;

namespace Ramsay.DataAccess
{
    public class RamsayUnitOfWork : IUnitOfWork
    {
        public RamsayUnitOfWork(string connectionString)
        {
            Student = new StudentRepository(connectionString);
        }

        public IStudentRepository Student { get; private set; }
    }
}
