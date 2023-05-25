using System.Linq.Expressions;

namespace Delegate_Training_Registration.DataAccess.Contracts
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(bool isTrackingChanges);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool isTrackingChanges);
    }
}
