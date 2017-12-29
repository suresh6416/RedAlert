using RedAlert.Common;
using RedAlert.Entities.ComplexModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Services.Contracts
{
   public interface IReportService
    {
       List<ReportModel> Get(ReportSearchInfo param);
    }
}
