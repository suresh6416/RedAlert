using RedAlert.Common;
using RedAlert.Entities.ComplexModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RedAlert.Controllers
{
    public class BaseController : ApiController
    {
        public static string LoggedInUserID
        {
            get
            {
                string userName = string.Empty;
                if (HttpContext.Current.Session[UIConstants.USER_INFO] != null)
                {
                    var userInfo = (UserInfo)HttpContext.Current.Session[UIConstants.USER_INFO];
                    userName = userInfo.ID.ToString();
                }

                return userName;
            }
        }

        public static string LoggedInUserName
        {
            get
            {
                string userName = string.Empty;
                if (HttpContext.Current.Session[UIConstants.USER_INFO] != null)
                {
                    var userInfo = (UserInfo)HttpContext.Current.Session[UIConstants.USER_INFO];
                    userName = userInfo.UserName;
                }

                return userName;
            }            
        }

        public static string LoggedInRole
        {
            get
            {
                string userName = string.Empty;
                if (HttpContext.Current.Session[UIConstants.USER_INFO] != null)
                {
                    var userInfo = (UserInfo)HttpContext.Current.Session[UIConstants.USER_INFO];
                    userName = userInfo.RoleName;
                }

                return userName;
            }
        }

        public static string LoggedInDepartment
        {
            get
            {
                string userName = string.Empty;
                if (HttpContext.Current.Session[UIConstants.USER_INFO] != null)
                {
                    var userInfo = (UserInfo)HttpContext.Current.Session[UIConstants.USER_INFO];
                    userName = userInfo.DepartmentName;
                }

                return userName;
            }
        }
    }
}
