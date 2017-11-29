using System;
using System.Collections.Generic;

namespace RedAlert.Entities.Models
{
    public partial class Activity
    {
        public Activity()
        {
            this.ActivityInfoes = new List<ActivityInfo>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public virtual ICollection<ActivityInfo> ActivityInfoes { get; set; }
    }
}
