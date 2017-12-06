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
        public int Count_ActivitiesToComplete { get; set; }
        public int Count_ActivitiesClosed { get; set; }
        public int Count_UserActivitiesToComplete { get; set; }
        public int Count_UserActivitiesClosed { get; set; }
    }

    public class DashboardResultParams : StoredProcedureParams
    {
        public string UserName { get; set; }
    }
}
