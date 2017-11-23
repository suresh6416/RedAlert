using System;
using System.Collections.Generic;

namespace RedAlert.Entities.Models
{
    public partial class Department
    {
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
