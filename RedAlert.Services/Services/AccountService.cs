using RedAlert.Common;
using RedAlert.Entities.ComplexModels;
using RedAlert.Entities.Context;
using RedAlert.Entities.Models;
using RedAlert.Entities.Repository;
using RedAlert.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Services.Services
{
    public class AccountService : IAccountService
    {
        APIContext _webcontext = new APIContext();

        public UserInfo Get(string userName)
        {
            var userInfo = StoredProcedure<UserInfo>.Execute(StoredProcedureName.PRC_GET_USER_INFO, new UserInfoParams { UserName = userName }).FirstOrDefault();
            return userInfo;
        }
    }
}
