using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.Core
{
   public interface IRepository<T> 
       where T:IHasId
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        StorageOperationResult Save(T entity);
        StorageOperationResult SaveMany(IEnumerable<T> entities);
        StorageOperationResult Delete(int id);
    }
}
