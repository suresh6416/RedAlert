using RedAlert.Common;
using RedAlert.Entities.ComplexModels;
using RedAlert.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedAlert.Controllers
{
   
    public class ReportController : ApiController
    {
        IReportService lReport;

        public ReportController(IReportService _lReport)
        {
            lReport = _lReport;
        }

        [HttpPost]
        public OperationResult Post(ReportSearchInfo reportSearchInfo)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lReport.Get(reportSearchInfo);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        
    }
}
