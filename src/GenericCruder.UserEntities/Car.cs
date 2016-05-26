using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.UserEntities.Cars
{
    public class Car : IHasId
    {
        public int CarID { get; set; }

        public string Producer { get; set; }

        public string ModelName { get; set; }

        public bool IsPublicVehicle { get; set; }

        int IHasId.Id
        {
            get
            {
                return CarID;
            }
            set
            {
                CarID = value;
            }
        }
    }
}
