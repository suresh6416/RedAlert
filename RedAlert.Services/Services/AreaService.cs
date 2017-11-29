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
    public class AreaService : IAreaService
    {
        APIContext _webcontext = new APIContext();

        public List<Area> Get()
        {
            return _webcontext.Areas.Where(m => m.IsActive == true).ToList();
        }

        public Area GetById(int id)
        {
            return _webcontext.Areas.Where(m => m.ID == id && m.IsActive == true).FirstOrDefault();
        }

        public void Save(Area data, string loggedInUserName)
        {
            if (data.ID == 0)
            {
                data.IsActive = true;
                data.CreatedBy = loggedInUserName;
                data.CreatedOn = DateTime.Now;
                _webcontext.Areas.Add(data);
            }
            else
            {
                var module = _webcontext.Areas.Where(m => m.ID == data.ID).FirstOrDefault();
                module.Name = data.Name;
                module.Code = data.Code;
                module.UpdatedBy = loggedInUserName;
                module.UpdatedOn = DateTime.Now;
            }

            _webcontext.SaveChanges();
        }

        public int GetCurrentRecordId()
        {
            var recordId = _webcontext.Areas.OrderByDescending(a => a.ID)
                            .Select(a => a.ID)
                            .FirstOrDefault();
            return ++recordId;
        }
    }
}
