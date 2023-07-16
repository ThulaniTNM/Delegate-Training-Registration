namespace Delegate_Training_Registration.DataAccess.Contracts
{
  public interface IGenericRepository<T>
  {
	IEnumerable<T> GetAll(bool isTrackingChanges);

	// allow to query by any entity via condition.
	// use for single resource, sub-collection resource & sub-collection individual resource.
	IEnumerable<T> GetByCondition(Func<T, bool> condition, bool isTrackingChanges);
	void Create(T entity);
	void Delete(T entity);
  }
}
