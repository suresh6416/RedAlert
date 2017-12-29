using RedAlert.Common;
using RedAlert.Entities.ComplexModels;
using RedAlert.Entities.Context;
using RedAlert.Entities.Repository;
using RedAlert.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RedAlert.Services.Services
{
    public class ReportService:IReportService
    {
        APIContext _webcontext = new APIContext();

        public List<ReportModel> Get(ReportSearchInfo param)
        {
            var sp = " PRC_GetReport   @Report= '" + param.Report + "',@ReportType='" + param.ReportType + "',@FromDate='" + param.FromDate + "',@ToDate='" + param.ToDate+"', @UserName='"+param.UserName+"', @Type='"+param.Type+"',@AreaType='"+param.AreaType+"'";
            var reportModel = StoredProcedure<ReportModel>.Execute(sp, new StoredProcedureParams()).ToList();
            return reportModel;
        }
    }
}
