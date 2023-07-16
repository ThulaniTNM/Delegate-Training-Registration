using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Delegate_Training_Registration.DataAccess.Repositories
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
	private readonly DelegateTrainingRegistrationContext _context;
	private DbSet<T> table;
	public GenericRepository(DelegateTrainingRegistrationContext context)
	{
	  this._context = context;
	  this.table = context.Set<T>();
	}

	public async Task<IEnumerable<T>> GetAll(bool isTrackingChanges)
	{
	  var resultSet = isTrackingChanges ? this.table.ToListAsync() : this.table.AsNoTracking().ToListAsync();
	  return await resultSet;
	}

	public async Task<IEnumerable<T>> GetByCondition(Func<T, bool> condition, bool isTrackingChanges)
	{
	  var resultSet = isTrackingChanges ? this.table.ToListAsync() : this.table.AsNoTracking().ToListAsync();
	  var filteredResultSet = await resultSet;
	  return filteredResultSet.Where(condition);
	}

	public async Task Create(T entity)
	{
	  await this.table.AddAsync(entity);
	}

	public void Delete(T entity)
	{
	  this.table.Remove(entity);
	}
  }
}
