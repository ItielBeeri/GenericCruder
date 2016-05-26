using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.UserEntities.People
{
    public class Person :IHasId
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        int IHasId.Id
        {
            get
            {
                return PersonId;
            }
            set
            {
                PersonId = value;
            }
        }
    }
}
