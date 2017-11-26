using RedAlert.Common;
using RedAlert.Entities.Models;
using RedAlert.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedAlert.Controllers
{
    [RoutePrefix("api/activity")]
    [Authorize]
    public class ActivityController : BaseController
    {
        IActivityService lActivity;
        public ActivityController(IActivityService _lActivity)
        {
            lActivity = _lActivity;
        }

        /// <summary>
        /// Get Activities
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public OperationResult Get()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lActivity.Get();
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get Activity By Id
        /// </summary>
        /// <param name="id">Activity Id</param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult GetById(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lActivity.GetById(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Add Activity
        /// </summary>
        /// <param name="module">model</param>
        /// <returns></returns>
        [HttpPost]
        public OperationResult Post(Activity activity)
        {
            OperationResult result = new OperationResult();
            try
            {
                lActivity.Save(activity, "");
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
