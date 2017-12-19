using RedAlert.Entities.Context;
using RedAlert.Entities.Models;
using RedAlert.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAlert.Common;
using RedAlert.Entities.ComplexModels;
using RedAlert.Entities.Repository;

namespace RedAlert.Services.Services
{
    public class ActivityInfoService : IActivityInfoService
    {
        APIContext _webcontext = new APIContext();
        
        public List<ActivityInfoResult> Get()
        {
            var activityInfo = StoredProcedure<ActivityInfoResult>.Execute(StoredProcedureName.PRC_GET_ACTIVITY_INFO, new StoredProcedureParams()).ToList();
            return activityInfo;
        }
        
        public ActivityInfoResult GetById(int id)
        {
            var activityInfo = StoredProcedure<ActivityInfoResult>.Execute(StoredProcedureName.PRC_GET_ACTIVITY_INFO, new ActivityInfoResultResultParams { ActivityInfoID=id }).FirstOrDefault();
            return activityInfo;
        }

        public void Save(ActivityInfo data, string loggedInUserName)
        {
            var activityInfo = _webcontext.ActivityInfoes.Where(m => m.ID == data.ID).FirstOrDefault();

            if (activityInfo == null)
            {
                data.IsActive = true;
                data.CreatedBy = loggedInUserName;
                data.CreatedOn = DateTime.Now;
                _webcontext.ActivityInfoes.Add(data);
            }
            else
            {                
                activityInfo.AreaId = data.AreaId;
                activityInfo.ActivityId = data.ActivityId;
                activityInfo.Type = data.Type;
                activityInfo.Periodicity = data.Periodicity;
                activityInfo.PeriodicityType = data.PeriodicityType;
                activityInfo.AdvnaceAlert = data.AdvnaceAlert;
                activityInfo.AdvnaceAlertType = data.AdvnaceAlertType;
                activityInfo.PreviousDate = data.PreviousDate;
                activityInfo.NextDueDate = data.NextDueDate;
                activityInfo.StartJobDate = data.StartJobDate;
                activityInfo.PreRespPerson = data.PreRespPerson;
                activityInfo.SecRespPerson = data.SecRespPerson;
                activityInfo.Status = data.Status;
                activityInfo.UpdatedBy = loggedInUserName;
                activityInfo.UpdatedOn = DateTime.Now;
            }

            _webcontext.SaveChanges();
        }

        public int GetCurrentRecordId()
        {
            var recordId = _webcontext.ActivityInfoes.OrderByDescending(a => a.ID)
                            .Select(a => a.ID)
                            .FirstOrDefault();
            return ++recordId;
        }
    }
}
