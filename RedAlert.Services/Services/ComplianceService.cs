using RedAlert.Common;
using RedAlert.Entities.ComplexModels;
using RedAlert.Entities.Context;
using RedAlert.Entities.Models;
using RedAlert.Entities.Repository;
using RedAlert.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAlert.Services.Services
{
    public class ComplianceService : IComplianceService
    {
        APIContext _webcontext = new APIContext();

        public List<ComplianceResult> Get(string userName)
        {
            var compliances = StoredProcedure<ComplianceResult>.Execute(StoredProcedureName.PRC_GET_COMPLIANCES, new ComplianceResultParams { ComplianceID = null, UserName = userName }).ToList();
            return compliances;
        }

        public ComplianceResult GetById(int id)
        {
            var compliance = StoredProcedure<ComplianceResult>.Execute(StoredProcedureName.PRC_GET_COMPLIANCES, new ComplianceResultParams { ComplianceID = id, UserName = null}).FirstOrDefault();
            return compliance;
        }

        public void Save(ComplianceResult data, string loggedInUserName)
        {
            var comp = _webcontext.Compliances.Where(m => m.ID == data.ComplianceId).FirstOrDefault();

            if (comp == null)
            {
                comp = new Compliance();

                comp.ActivityInfoId = data.ID;
                comp.Description = data.Description;
                comp.DueDate = data.DueDate;
                comp.CompletionDate = data.CompletionDate;
                comp.IsDelayed = data.IsDelayed;
                comp.ReasonForDelay = data.ReasonForDelay;
                comp.IsDelayAcceptable = data.IsDelayAcceptable;
                comp.Remarks = data.Remarks;
                comp.HasDeviation = data.HasDeviation;
                comp.DeviationDesc = data.DeviationDesc;
                comp.IsDeviationAcceptable = data.IsDeviationAcceptable;
                comp.IsActive = true;
                comp.CreatedBy = loggedInUserName;
                comp.CreatedOn = DateTime.Now;

                _webcontext.Compliances.Add(comp);
            }
            else
            {
                comp.ActivityInfoId = data.ID;
                comp.Description = data.Description;
                comp.DueDate = data.DueDate;
                comp.CompletionDate = data.CompletionDate;
                comp.IsDelayed = data.IsDelayed;
                comp.ReasonForDelay = data.ReasonForDelay;
                comp.IsDelayAcceptable = data.IsDelayAcceptable;
                comp.Remarks = data.Remarks;
                comp.HasDeviation = data.HasDeviation;
                comp.DeviationDesc = data.DeviationDesc;
                comp.IsDeviationAcceptable = data.IsDeviationAcceptable;
                comp.UpdatedBy = loggedInUserName;
                comp.UpdatedOn = DateTime.Now;
            }            

            //Update status
            var actInfo = _webcontext.ActivityInfoes.Where(m => m.ID == data.ID).FirstOrDefault();
            if(actInfo != null)
            {
                actInfo.Status = data.Status;
                actInfo.UpdatedBy = loggedInUserName;
                actInfo.UpdatedOn = DateTime.Now;
            }
            _webcontext.SaveChanges();
        }

        public int GetCurrentRecordId()
        {
            var recordId = _webcontext.Compliances.OrderByDescending(a => a.ID)
                            .Select(a => a.ID)
                            .FirstOrDefault();
            return ++recordId;
        }
    }
}
