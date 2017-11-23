using RedAlert.Common;
using RedAlert.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedAlert.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        IAccountService lAccount;
        public AccountController(IAccountService _lAccount)
        {
            lAccount = _lAccount;
        }

        /// <summary>
        /// Get Accounts
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public OperationResult Get()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = lAccount.Get();
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
