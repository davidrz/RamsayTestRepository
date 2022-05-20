using Ramsay.Repositories;

namespace Ramsay.UnitOfWork
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
    }
}
