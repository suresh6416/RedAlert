using System;
using System.Collections.Generic;

namespace RedAlert.Entities.Models
{
    public partial class User
    {
        public System.Guid ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<System.Guid> RoleId { get; set; }
        public Nullable<System.Guid> DepartmentId { get; set; }
    }
}
