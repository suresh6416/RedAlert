using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAlert.Services.Contracts;
using RedAlert.Entities.ComplexModels;
using RedAlert.Entities.Context;

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

        public List<DataLookupModel> StatusLookup()
        {
            var result = (from d in new APIContext().Areas
                          where d.IsActive == true
                          select new DataLookupModel { ID = d.ID, Name = d.Code }).ToList();
            return result;

        }
    }
}
