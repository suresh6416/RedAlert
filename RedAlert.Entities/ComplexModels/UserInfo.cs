using RedAlert.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Entities.ComplexModels
{
    public class UserInfo
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }
    }

    public class UserInfoParams : StoredProcedureParams
    {
        public string UserName { get; set; }
    }

}
