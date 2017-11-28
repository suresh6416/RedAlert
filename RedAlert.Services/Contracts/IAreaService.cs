using RedAlert.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Services.Contracts
{
    public interface IAreaService
    {
        List<Area> Get();
        Area GetById(int id);
        void Save(Area data, string loggedInUserName);
        int GetCurrentRecordId();
    }
}
