using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Entities.ComplexModels
{
    public class ReportModel
    {
        public string Area { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public string CompletionDate { get; set; }
        public string Responsibility { get; set; }
        public string Deviations { get; set; }
        public string Remarks { get; set; }
        public string Type { get; set; }
        public string AlertDate { get; set; }
        public string ComplitionStatus { get; set; }
        public string PreviousDate { get; set; }
        public int Periodicity { get; set; }
        public string NextDueDate { get; set; }
        public string AlertPeriod { get; set; }
    }
}
