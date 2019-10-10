using Pradadge.Common.Extentions;
using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.Entities.Model;
using Pradadge.ViewModel.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pradadge.Data.DataRepository.Business
{
    public class ReferenceManagerRepository : IReferenceManagerRepository
    {
        int maxNo = 0;
        PradadgeContext context;

        public ReferenceManagerRepository(PradadgeContext context)
        {
            this.context = context;
        }

        public string GetReferenceNo(int referenceType, int companyId)
        {
            
            if (maxNo == 0)
            {
                var lastCount = context.tbl_ReferenceManager.
                    Where(c => c.CompanyId == companyId && c.ReferenceType == referenceType).ToList();


                maxNo = lastCount.Count == 0 ? 0 : lastCount.Max(c => c.SeriaNo);

                ++maxNo;
            }
            return maxNo.ToString().PadZeros();
        }

        public string ConfirmReferenceNo( int referenceType, int companyId)
        {
            tbl_ReferenceManager data = null;
            if (maxNo == 0)
            {
                var lastCount = context.tbl_ReferenceManager.
                    Where(c => c.CompanyId == companyId  && c.ReferenceType == referenceType).ToList();                
                maxNo = lastCount.Count == 0 ? 0: lastCount.Max(c => c.SeriaNo);
                ++maxNo;
            }
            else
            {
                maxNo++;
            }

            var reference = context.tbl_ReferenceManager
                            .Where(c => c.SeriaNo == maxNo &&  c.ReferenceType == referenceType);

            if (reference.Any())
            {
                ConfirmReferenceNo(referenceType, companyId);
            }
            else
            {
                data = new tbl_ReferenceManager
                {
                    ReferenceNo = maxNo.ToString().PadZeros(),
                    ReferenceType = referenceType,
                    SeriaNo = maxNo,
                    ValidReference = true,
                    CreatedOn = DateTime.Now,
                    CompanyId = companyId
                };
                context.tbl_ReferenceManager.Add(data);

                context.SaveChanges();
            }

            return data.ReferenceNo;

        }

        
    }
}
