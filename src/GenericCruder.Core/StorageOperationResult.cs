using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.Core
{
    public class StorageOperationResult
    {
        public static readonly IEnumerable<int> EmptyOperation = new int[0];

        public IEnumerable<int> Inserted { get; set; }

        public IEnumerable<int> Updated { get; set; }

        public IEnumerable<int> Deleted { get; set; }

        public IEnumerable<StorageOperationError> Errors { get; set; }

        public StorageOperationResult()
            :this(EmptyOperation, EmptyOperation, EmptyOperation){}

        public StorageOperationResult(IEnumerable<int> inserted, IEnumerable<int> updated, IEnumerable<int> deleted)
        {
            Inserted = inserted;
            Updated = updated;
            Deleted = deleted;
            Errors = null;
        }
    }
}
