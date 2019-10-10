using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface ICompanysRepository
    {
        IEnumerable<CompanyViewModel> GetCompanyDetails();
        CompanyViewModel AddCompany(CompanyViewModel company);
        IQueryable<CompanyViewModel> GetCompanyById(int id);
        bool UpdateCompanyDetails(CompanyViewModel entity);
    }
}
