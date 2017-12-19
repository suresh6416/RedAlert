using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAlert.Entities.Context;
using RedAlert.Entities.ComplexModels;
using RedAlert.Services.Contracts;

namespace RedAlert.Services.Services
{
    public class DataLookupService : IDataLookupService
    {
        public List<DataLookupModel> AreaLookup()
        {
            var result = (from d in new APIContext().Areas
                          where d.IsActive == true
                          select new DataLookupModel { ID = d.ID, Name = d.Code }).ToList();
            return result;

        }

        public List<DataLookupModel> ActivityLookup()
        {
            var result = (from d in new APIContext().Activities
                          where d.IsActive == true
                          select new DataLookupModel { ID = d.ID, Name = d.Description }).ToList();
            return result;

        }

        public List<DataLookupModel> UsersLookup()
        {
            var result = (from d in new APIContext().Users
                          select new DataLookupModel { Name = d.UserName }).ToList();
            return result;

        }
    }
}
