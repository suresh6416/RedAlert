using RedAlert.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAlert.Entities.ComplexModels;
namespace RedAlert.Services.Contracts
{
    public interface IActivityInfoService
    {
        List<ActivityInfoResult> Get();
        ActivityInfoResult GetById(int id);
        void Save(ActivityInfo data, string loggedInUserName);
        int GetCurrentRecordId();
    }
}
