using RedAlert.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Entities.ComplexModels
{
    public class ComplianceResult
    {
        public int ID { get; set; }
        public int? ComplianceId { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public Nullable<DateTime> CompletionDate { get; set; }
        public bool? IsDelayed { get; set; }
        public string ReasonForDelay { get; set; }
        public bool? IsDelayAcceptable { get; set; }
        public string Remarks { get; set; }
        public bool? HasDeviation { get; set; }
        public string DeviationDesc { get; set; }
        public bool? IsDeviationAcceptable { get; set; }
        public string Status { get; set; }
        public string PreRespPerson { get; set; }
        public string SecRespPerson { get; set; }
    }

    public class ComplianceResultParams: StoredProcedureParams
    {
        public int? ComplianceID { get; set; }
        public string UserName { get; set; }
    }   
}
