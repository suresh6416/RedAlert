using RedAlert.Entities.ComplexModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Services.Contracts
{
    public interface IComplianceService
    {
        List<ComplianceResult> Get();
        ComplianceResult GetById(int id);
        void Save(ComplianceResult data, string loggedInUserName);
        int GetCurrentRecordId();
    }
}
