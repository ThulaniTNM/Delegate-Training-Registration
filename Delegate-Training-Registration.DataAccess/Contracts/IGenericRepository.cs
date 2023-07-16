namespace Delegate_Training_Registration.DataAccess.Contracts
{
  public interface IGenericRepository<T>
  {
	Task<IEnumerable<T>> GetAll(bool isTrackingChanges);

	// allow to query by any entity via condition.
	// use for single resource, sub-collection resource & sub-collection individual resource.
	Task<IEnumerable<T>> GetByCondition(Func<T, bool> condition, bool isTrackingChanges);
	Task Create(T entity);
	void Delete(T entity);
  }
}
