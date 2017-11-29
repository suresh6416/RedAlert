using System;
using System.Collections.Generic;

namespace RedAlert.Entities.Models
{
    public partial class ActivityInfo
    {
        public ActivityInfo()
        {
            this.Compliances = new List<Compliance>();
        }

        public int ID { get; set; }
        public Nullable<int> AreaId { get; set; }
        public Nullable<int> ActivityId { get; set; }
        public string Type { get; set; }
        public Nullable<int> Periodicity { get; set; }
        public string PeriodicityType { get; set; }
        public Nullable<int> AdvnaceAlert { get; set; }
        public string AdvnaceAlertType { get; set; }
        public Nullable<System.DateTime> PreviousDate { get; set; }
        public Nullable<System.DateTime> NextDueDate { get; set; }
        public Nullable<System.DateTime> StartJobDate { get; set; }
        public string PreRespPerson { get; set; }
        public string SecRespPerson { get; set; }
        public string Status { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual ICollection<Compliance> Compliances { get; set; }
        public virtual Area Area { get; set; }
    }
}
