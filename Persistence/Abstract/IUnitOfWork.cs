using System.Threading.Tasks;

namespace Persistence.Abstract
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}