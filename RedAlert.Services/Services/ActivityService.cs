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
    public class ActivityService : IActivityService
    {
        APIContext _webcontext = new APIContext();

        public List<Activity> Get()
        {
            return _webcontext.Activities.Where(m => m.IsActive == true).ToList();
        }

        public Activity GetById(int id)
        {
            return _webcontext.Activities.Where(m => m.ID == id && m.IsActive == true).FirstOrDefault();
        }

        public void Save(Activity data, string loggedInUserName)
        {
            var module = _webcontext.Activities.Where(m => m.ID == data.ID).FirstOrDefault();

            if (module == null)
            {
                data.IsActive = true;
                data.CreatedBy = loggedInUserName;
                data.CreatedOn = DateTime.Now;
                _webcontext.Activities.Add(data);
            }
            else
            {                
                module.Description = data.Description;
                module.UpdatedBy = loggedInUserName;
                module.UpdatedOn = DateTime.Now;
            }

            _webcontext.SaveChanges();

        }

        public int GetCurrentRecordId()
        {           
            var recordId = _webcontext.Activities.OrderByDescending(a => a.ID)
                            .Select(a => a.ID)
                            .FirstOrDefault();            
            return ++recordId;
        }
    }
}
