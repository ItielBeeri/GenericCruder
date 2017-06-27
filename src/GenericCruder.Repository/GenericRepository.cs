using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.GenericCruder.Core;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Reflection;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Metadata.Edm;

namespace ETL.GenericCruder.Repository
{
    public class GenericRepository<T> : IRepository<T>, IDisposable
        where T : class, IHasId
    {
        private DbContext _context;
        private DbSet<T> _set;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _set.ToArray();
        }

        public T GetById(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _set.Where(predicate).ToArray();
        }

        public StorageOperationResult Save(T entity)
        {
            return SaveMany(new T[] { entity });
        }

        public StorageOperationResult SaveMany(IEnumerable<T> entities)
        {
            List<T> inserted = new List<T>();
            List<T> updated = new List<T>();
            foreach (T entity in entities)
            {
                Save(entity, inserted, updated);
            }
            try
            {
                _context.SaveChanges();
                return new StorageOperationResult(inserted.Select(en => en.Id), updated.Select(en => en.Id), StorageOperationResult.EmptyOperation);
            }
            catch (DbUpdateException ex)
            {
                return new StorageOperationResult() { Errors = ex.Entries.Select(entry => new StorageOperationError(((T)entry.Entity).Id, typeof(T).Name, ex.Message)) };
            }
        }

        internal void Save(T entity, List<T> inserted, List<T> updated)
        {
            HashSet<object> toAdd = new HashSet<object>(), other = new HashSet<object>();
            if (entity != null)
            {
                ScanGraph(entity, toAdd, other);
            }
            foreach (object item in toAdd)
            {
                _context.Entry(item).State = EntityState.Added;
                if (item==entity)
                {
                    inserted.Add(entity);
                }
            }
            foreach (object item in other)
            {
                if (item==entity)
                { 
                    _context.Entry(item).State = EntityState.Modified;
                    updated.Add(entity);
                }
                else
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
            }
        }

        private void ScanGraph(IHasId entity, HashSet<object> toAdd, HashSet<object> other)
        {
            if (!toAdd.Contains(entity) && !other.Contains(entity))
            {
                (entity.Id == 0 ? toAdd : other).Add(entity);

                ObjectContext objContext = ((IObjectContextAdapter)_context).ObjectContext;
                Type entityClrType = entity.GetType();
                EntityType entityType = objContext.MetadataWorkspace.GetItems<EntityType>(DataSpace.CSpace).Single(t=>t.Name==entityClrType.Name);

                foreach (NavigationProperty prop in entityType.NavigationProperties)
                {
                    string propertyName = prop.Name;
                    Type propertyType = entity.GetType().GetProperty(propertyName).PropertyType;
                    bool isCollection = typeof(IEnumerable).IsAssignableFrom(propertyType);
                    if (isCollection)
                    {
                        IEnumerable collection = (IEnumerable)_context.Entry(entity).Collection(propertyName).CurrentValue;
                        if (collection != null)
                        {
                            foreach (var item in collection)
                            {
                                if (item != null)
                                {
                                    ScanGraph((IHasId)item, toAdd, other);
                                }
                            }
                        }
                    }
                    else
                    {
                        IHasId referenceEntity = (IHasId)_context.Entry(entity).Reference(propertyName).CurrentValue;
                        if (referenceEntity != null)
                        {
                            ScanGraph(referenceEntity, toAdd, other);
                        }
                    }
                }
            }
        }

        public StorageOperationResult Delete(int id)
        {
            T entity = _set.Find(id);
            if (entity == null)
            {
                StorageOperationError error = new StorageOperationError(id, typeof(T).Name, "The entity requested for deletion was not found in the data storage");
                return new StorageOperationResult() { Errors = new StorageOperationError[] { error } };
            }
            _set.Remove(entity);
            try
            {
                _context.SaveChanges();
                return new StorageOperationResult(StorageOperationResult.EmptyOperation, StorageOperationResult.EmptyOperation, new int[] { id });
            }
            catch (DbUpdateException ex)
            {
                return new StorageOperationResult() { Errors = ex.Entries.Select(entry => new StorageOperationError(((T)entry.Entity).Id, typeof(T).Name, ex.Message)) };
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
