using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.Core
{
    public class StorageOperationError
    {
        public int EntityId { get; set; }

        public string EntityTypeName { get; set; }

        public string ErrorMessage { get; set; }

        public StorageOperationError(int entityId, string entityTypeName, string errorMessage)
        {
            EntityId = entityId;
            EntityTypeName = entityTypeName;
            ErrorMessage = errorMessage;
        }
    }
}
