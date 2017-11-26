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
            if (data.ID == 0)
            {
                data.IsActive = true;
                data.CreatedBy = loggedInUserName;
                data.CreatedOn = DateTime.Now;
                _webcontext.ActivityInfoes.Add(data);
            }
            else
            {
                var module = _webcontext.ActivityInfoes.Where(m => m.ID == data.ID).FirstOrDefault();
                module.AreaId = data.AreaId;
                module.ActivityId = data.ActivityId;
                module.Type = data.Type;
                module.Periodicity = data.Periodicity;
                module.PeriodicityType = data.PeriodicityType;
                module.AdvnaceAlert = data.AdvnaceAlert;
                module.AdvnaceAlertType = data.AdvnaceAlertType;
                module.PreviousDate = data.PreviousDate;
                module.NextDueDate = data.NextDueDate;
                module.StartJobDate = data.StartJobDate;
                module.PreRespPerson = data.PreRespPerson;
                module.SecRespPerson = data.SecRespPerson;
                module.Status = data.Status;
                module.UpdatedBy = loggedInUserName;
                module.UpdatedOn = DateTime.Now;
            }

            _webcontext.SaveChanges();
        }
    }
}
