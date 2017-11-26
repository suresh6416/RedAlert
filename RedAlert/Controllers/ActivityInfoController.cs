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
    [RoutePrefix("api/activityInfo")]
    [Authorize]
    public class ActivityInfoController : BaseController
    {
        IActivityInfoService lActivityInfo;
        public ActivityInfoController(IActivityInfoService _lActivityInfo)
        {
            lActivityInfo = _lActivityInfo;
        }

        /// <summary>
        /// Get Activities Info
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public OperationResult Get()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lActivityInfo.Get();
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get Activity Info By Id
        /// </summary>
        /// <param name="id">Activity Info Id</param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult GetById(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lActivityInfo.GetById(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Add Activity Info
        /// </summary>
        /// <param name="module">model</param>
        /// <returns></returns>
        [HttpPost]
        public OperationResult Post(ActivityInfo activity)
        {
            OperationResult result = new OperationResult();
            try
            {
                lActivityInfo.Save(activity, "");
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
