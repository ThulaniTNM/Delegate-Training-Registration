namespace Delegate_Training_Registration.DataAccess.Contracts
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll(bool isTrackingChanges);
        IEnumerable<T> GetByCondition(Func<T, bool> condition, bool isTrackingChanges);
        void Create(T entity);
    }
}
