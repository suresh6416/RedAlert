using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedAlert.Services.Contracts;
using RedAlert.Common;
using System.Web.Http;
using RedAlert.Entities.Models;



namespace RedAlert.Controllers
{

    [RoutePrefix("api/DataLookup")]
    [Authorize]
    public class DataLookupController : BaseController
    {
        IDataLookupService lDataLookup;
        public DataLookupController(IDataLookupService _lDataLookup)
        {
            lDataLookup = _lDataLookup;
        }

        [HttpGet]
        [Route("AreaLookup")]
        public OperationResult AreaLookup()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lDataLookup.AreaLookup();
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("ActivityLookup")]
        public OperationResult ActivityLookup()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lDataLookup.ActivityLookup();
                result.Status = OperationStatus.SUCCESS;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("UsersLookup")]
        public OperationResult UsersLookup()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lDataLookup.UsersLookup();
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