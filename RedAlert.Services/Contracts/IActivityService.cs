using RedAlert.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Services.Contracts
{
    public interface IActivityService
    {
        List<Activity> Get();
        Activity GetById(int id);
        void Save(Activity data, string loggedInUserName);
        int GetCurrentRecordId();
    }
}
