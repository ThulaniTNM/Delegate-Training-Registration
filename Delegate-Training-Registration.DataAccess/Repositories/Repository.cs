using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Delegate_Training_Registration.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DelegateTrainingRegistrationContext _context;
        private DbSet<T> entity;
        public Repository(DelegateTrainingRegistrationContext context)
        {
            this._context = context;
            this.entity = context.Set<T>();
        }
        public IQueryable<T> GetAll(bool isTrackingChanges)
        {
            var resultSet = isTrackingChanges ? this.entity : this.entity.AsNoTracking();
            return resultSet;
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool isTrackingChanges)
        {
            var resultSet = isTrackingChanges ?
                                    this.entity.Where(expression)
                                    : this.entity.Where(expression).AsNoTracking();

            return resultSet;
        }
    }
}
