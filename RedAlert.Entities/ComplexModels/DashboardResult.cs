using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAlert.Common;

namespace RedAlert.Entities.ComplexModels
{
    public class DashboardResult
    {
        public double Count_ActivitiesToComplete { get; set; }
        public double Count_ActivitiesClosed { get; set; }
        public double Count_UserActivitiesToComplete { get; set; }
        public double Count_UserActivitiesClosed { get; set; }
    }

    public class DashboardResultParams : StoredProcedureParams
    {
        public string UserName { get; set; }
    }
}
