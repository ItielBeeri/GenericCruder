using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.UserEntities.HouseCommittee
{
    public class Task :IHasId
    {
        public int TaskID { get; set; }
        public string TaskContent { get; set; }
        public string Title { get; set; }

        int IHasId.Id
        {
            get
            {
                return TaskID;
            }
            set
            {
                TaskID = value;
            }
        }
    }

    public class Message :IHasId
    {
        public int MessageID { get; set; }
        public string MessageText { get; set; }
        public string Title { get; set; }

        int IHasId.Id
        {
            get
            {
                return MessageID;
            }
            set
            {
                MessageID = value;
            }
        }
    }
}
