using System;
using System.Collections.Generic;

namespace RedAlert.Entities.Models
{
    public partial class Compliance
    {
        public int ID { get; set; }
        public Nullable<int> ActivityInfoId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public Nullable<bool> IsDelayed { get; set; }
        public string ReasonForDelay { get; set; }
        public Nullable<bool> IsDelayAcceptable { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> HasDeviation { get; set; }
        public string DeviationDesc { get; set; }
        public Nullable<bool> IsDeviationAcceptable { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public virtual ActivityInfo ActivityInfo { get; set; }
    }
}
