using RedAlert.Entities.Context;
using RedAlert.Entities.Models;
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

        public List<User> Get()
        {
            return _webcontext.Users.ToList();
        }
    }
}
