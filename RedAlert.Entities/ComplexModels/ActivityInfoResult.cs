using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAlert.Common;

namespace RedAlert.Entities.ComplexModels
{
    public class ActivityInfoResult
    {
        public int ID { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ActivityId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Periodicity { get; set; }
        public string PeriodicityType { get; set; }
        public int AdvnaceAlert { get; set; }
        public string AdvnaceAlertType { get; set; }
        public Nullable<System.DateTime> PreviousDate { get; set; }
        public Nullable<System.DateTime> NextDueDate { get; set; }
        public Nullable<System.DateTime> StartJobDate { get; set; }
        public string PreRespPerson { get; set; }
        public string SecRespPerson { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }

    public class ActivityInfoResultResultParams : StoredProcedureParams
    {
        public int ActivityInfoID { get; set; }
    }
}
