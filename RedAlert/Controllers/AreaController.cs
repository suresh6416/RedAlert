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
    [RoutePrefix("api/area")]
    [Authorize]
    public class AreaController : BaseController
    {
        IAreaService lArea;
        public AreaController(IAreaService _lArea)
        {
            lArea = _lArea;
        }

        /// <summary>
        /// Get Areas
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public OperationResult Get()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lArea.Get();
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Get Area By Id
        /// </summary>
        /// <param name="id">Area Id</param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult GetById(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lArea.GetById(id);
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Add Area
        /// </summary>
        /// <param name="module">model</param>
        /// <returns></returns>
        [HttpPost]
        public OperationResult Post(Area area)
        {
            OperationResult result = new OperationResult();
            try
            {
                lArea.Save(area, "");
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
                result.Data = lArea.GetCurrentRecordId();
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
