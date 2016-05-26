using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.Core
{
    public class SubApplication
    {
        public int SubApplicationId { get; set; }

        public string ApplicationName { get; set; }

        private List<Type> _applicationTypes;

        public List<Type> ApplicationTypes
        {
            get { return _applicationTypes; }
        }

        public SubApplication()
        {
            _applicationTypes = new List<Type>();
        }
    }
}
