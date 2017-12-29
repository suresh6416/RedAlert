using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Entities.ComplexModels
{
    public  class ReportSearchInfo
    {
         public string  Report { get; set; }
         public string  ReportType { get; set; }
         public string  FromDate { get; set; }
         public string  ToDate { get; set; }
         public string UserName { get; set; }
         public string Type { get; set; }
         public int AreaType{ get; set; }
    }
}
