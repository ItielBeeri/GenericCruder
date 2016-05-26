using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.UserEntities.Gantt
{
    public class task : IHasId
    {
        public int taskId { get; set; }
        public string title { get; set; }
        public int? parentId { get; set; }
        public int? orderId { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public double? percentComplete { get; set; }
        public bool? summary { get; set; }
        public bool? expanded { get; set; }
        public int? duration { get; set; }

        int IHasId.Id
        {
            get { return taskId; }
            set { taskId = value; }
        }
    }

    [Table("SimTasks")]
    public class simTask : task
    {
        public DateTime? receiptDate { get; set; }
        public int? actualDevelopment { get; set; }
        public string remarks { get; set; }
        public virtual HashSet<employeePart> resourceList { get; set; }
        public virtual HashSet<employeePart> consultantList { get; set; }
    }

    [Table("Projects")]
    public class project : task
    {
        public string customer { get; set; }
        public virtual managerDetails projectManager { get; set; }
        public virtual managerDetails developmentManager { get; set; }
    }

    public class employeePart : IHasId
    {
        public int employeePartId { get; set; }
        public string name { get; set; }
        public double? percent { get; set; }
        public bool? @checked { get; set; }

        int IHasId.Id
        {
            get { return employeePartId; }
            set { employeePartId = value; }
        }
    }

    public class managerDetails : IHasId
    {
        public int managerDetailsId { get; set; }
        public string name { get; set; }
        public int? mobile { get; set; }
        public string email { get; set; }

        int IHasId.Id
        {
            get { return managerDetailsId; }
            set { managerDetailsId = value; }
        }
    }
}
