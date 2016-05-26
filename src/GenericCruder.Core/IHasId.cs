using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.Core
{
    public interface IHasId
    {
        int Id { get; set; }
    }
}
