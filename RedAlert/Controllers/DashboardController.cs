using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedAlert.Common;
using RedAlert.Entities.ComplexModels;
using RedAlert.Services.Contracts;
using System.Web.Http;

namespace RedAlert.Controllers
{
    public class DashboardController : BaseController
    {
        IDashboardService lDashboard;

        public DashboardController(IDashboardService _lDashboard)
        {
            lDashboard = _lDashboard;
        }


        /// <summary>
        /// Get Dashboard Activities progress
        /// </summary>

        [HttpGet]
        public OperationResult Get()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lDashboard.Get();
                result.Status = OperationStatus.SUCCESS;
            }
            catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}