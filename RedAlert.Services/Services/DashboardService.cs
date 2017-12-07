using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAlert.Common;
using RedAlert.Entities.ComplexModels;
using RedAlert.Entities.Context;
using RedAlert.Entities.Models;
using RedAlert.Entities.Repository;
using RedAlert.Services.Contracts;

namespace RedAlert.Services.Services
{

    public class DashboardService : IDashboardService
    {
        APIContext _webcontext = new APIContext();

        public DashboardResult Get()
        {
            var activitiesProgress = StoredProcedure<DashboardResult>.Execute(StoredProcedureName.PRC_GET_ACTIVITIES_PROGRESS, new DashboardResultParams {UserName="ramesh" }).FirstOrDefault();
            return activitiesProgress;
        }
    }
}
