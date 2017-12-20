﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAlert.Entities.ComplexModels;

namespace RedAlert.Services.Contracts
{
    public interface IDashboardService
    {
        DashboardResult Get();
        List<ToDoListResult> GetToDoList();
    }
}
