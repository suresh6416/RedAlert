using RedAlert.Common;
using RedAlert.Entities.ComplexModels;
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
    [RoutePrefix("api/compliance")]
    [Authorize]
    public class ComplianceController : BaseController
    {
        IComplianceService lCompliance;
        public ComplianceController(IComplianceService _lCompliance)
        {
            lCompliance = _lCompliance;
        }

        /// <summary>
        /// Get Compliances
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public OperationResult Get()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lCompliance.Get(LoggedInUserName);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get Compliance By Id
        /// </summary>
        /// <param name="id">Compliance Id</param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult GetById(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lCompliance.GetById(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Add Compliance
        /// </summary>
        /// <param name="module">model</param>
        /// <returns></returns>
        [HttpPost]
        public OperationResult Post(ComplianceResult compliance)
        {
            OperationResult result = new OperationResult();
            try
            {
                lCompliance.Save(compliance, LoggedInUserName);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get Current RecordId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCurrentRecordId")]
        public OperationResult GetCurrentRecordId()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lCompliance.GetCurrentRecordId();
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
