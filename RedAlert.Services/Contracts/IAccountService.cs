﻿using RedAlert.Entities.ComplexModels;
using RedAlert.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Services.Contracts
{
    public interface IAccountService
    {
        UserInfo Get(string userName);
    }
}
