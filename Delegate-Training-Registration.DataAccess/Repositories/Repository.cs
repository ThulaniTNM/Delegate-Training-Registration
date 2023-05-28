using Delegate_Training_Registration.DataAccess.Contracts;
using Delegate_Training_Registration.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Delegate_Training_Registration.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DelegateTrainingRegistrationContext _context;
        private DbSet<T> table;
        public Repository(DelegateTrainingRegistrationContext context)
        {
            this._context = context;
            this.table = context.Set<T>();
        }

        // use for collection resource not dependent of primary record existence.
        public IEnumerable<T> GetAll(bool isTrackingChanges)
        {
            var resultSet = isTrackingChanges ? this.table : this.table.AsNoTracking();
            return resultSet;
        }

        // allow to query by any entity field.
        // use for single resource, sub-collection resource & sub-collection individual resource.
        public IEnumerable<T> GetByCondition(Func<T, bool> condition, bool isTrackingChanges)
        {
            var resultSet = isTrackingChanges ? this.table.Where(condition) : this.table.AsNoTracking().Where(condition);
            return resultSet;
        }
    }
}
