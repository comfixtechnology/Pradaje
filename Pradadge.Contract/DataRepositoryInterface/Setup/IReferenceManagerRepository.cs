using Pradadge.ViewModel.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IReferenceManagerRepository
    {
        string GetReferenceNo(int referenceType, int companyId);

        string ConfirmReferenceNo(int referenceType, int companyId);
    }
}
