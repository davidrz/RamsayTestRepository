using Ramsay.Models;
using System.Threading.Tasks;

namespace Ramsay.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<bool> DeleteStudent(int id);
    }
}
