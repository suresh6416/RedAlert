using RedAlert.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Services.Contracts
{
    public interface IActivityInfoService
    {
        List<ActivityInfo> Get();
        ActivityInfo GetById(int id);
        void Save(ActivityInfo data, string loggedInUserName);
        int GetCurrentRecordId();
    }
}
