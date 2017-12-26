using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RedAlert.Services.Contracts;
using RedAlert.Common;

namespace RedAlert.Controllers
{  
    [RoutePrefix("api/dashboard")]
    [Authorize]
    public class DashboardController : BaseController
    {
        IDashboardService lDashboard;

        public DashboardController(IDashboardService _lDashboard)
        {
            lDashboard = _lDashboard;
        }
        /// <summary>
        /// Get Activities count
        /// </summary>
        /// <returns></returns>      

        [HttpGet]
        public OperationResult Get(string user)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lDashboard.Get(user);
                result.Status = OperationStatus.SUCCESS;
            }
            catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("GetToDoList")]
        public OperationResult GetToDoList(string user)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lDashboard.GetToDoList(user);
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