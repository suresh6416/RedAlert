using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedAlert.Common;

namespace RedAlert.Entities.ComplexModels
{
    public class ToDoListResult
    {
        public string Description { get; set; }
        public int ID { get; set; }
        public int ActivityId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class ToDoListParams:StoredProcedureParams
    {
        public string UserName { get; set; }
    }
}
