﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAlert.Common;
using RedAlert.Entities.ComplexModels;
using RedAlert.Entities.Context;
using RedAlert.Entities.Models;
using RedAlert.Entities.Repository;
using RedAlert.Services.Contracts;

namespace RedAlert.Services.Services
{
  
    public class DashboardService : IDashboardService
    {
        APIContext _webcontext = new APIContext();

        public DashboardResult Get(string loggedInUserName)
        {
            var activitiesProgress = StoredProcedure<DashboardResult>.Execute(StoredProcedureName.PRC_GET_ACTIVITIES_PROGRESS, new DashboardResultParams {UserName=loggedInUserName }).FirstOrDefault();
            return activitiesProgress;
        }

        public List<ToDoListResult> GetToDoList(string loggedInUserName)
        {
            var toDoList = StoredProcedure<ToDoListResult>.Execute(StoredProcedureName.PRC_GET_TODO_LIST, new ToDoListParams { UserName = loggedInUserName }).ToList();
            return toDoList;
        }
    }
}
