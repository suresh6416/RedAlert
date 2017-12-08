using RedAlert.Entities.Context;
using RedAlert.Entities.Models;
using RedAlert.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Services.Services
{
    public class ActivityInfoService : IActivityInfoService
    {
        APIContext _webcontext = new APIContext();

        public List<ActivityInfo> Get()
        {
            return _webcontext.ActivityInfoes.Where(m => m.IsActive == true).ToList();
        }

        public ActivityInfo GetById(int id)
        {
            return _webcontext.ActivityInfoes.Where(m => m.ID == id && m.IsActive == true).FirstOrDefault();
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
