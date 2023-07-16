﻿using Delegate_Training_Registration.DataAccess.Contracts;
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

	public IEnumerable<T> GetAll(bool isTrackingChanges)
	{
	  var resultSet = isTrackingChanges ? this.table : this.table.AsNoTracking();
	  return resultSet;
	}

	public IEnumerable<T> GetByCondition(Func<T, bool> condition, bool isTrackingChanges)
	{
	  var resultSet = isTrackingChanges ? this.table.Where(condition) : this.table.AsNoTracking().Where(condition);
	  return resultSet;
	}

	public void Create(T entity)
	{
	  this.table.Add(entity);
	}

	public void Delete(T entity)
	{
	  this.table.Remove(entity);
	}
  }
}
