using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.Entities.Model;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Data.DataRepository.Setup
{
    public class CompanysRepository : ICompanysRepository
    {
        private PradadgeContext context;
        public CompanysRepository (PradadgeContext context)
        {
            this.context = context;
        }

        public CompanyViewModel AddCompany(CompanyViewModel company)
        {
            var data = new tbl_Company
            {
                CompanyId = company.companyId,
                CompanyName = company.companyName,
                CompanyAddress = company.companyAddress,
                PhoneNo = company.phoneNo,
                Email = company.email,
                Website = company.website,
                CompanyLogo = company.companyLogo,
                IsActive = company.isActive,
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                ModifiedBy = "admin",
                ModifiedOn = DateTime.Now
            };

            context.tbl_Company.Add(data);
            context.SaveChanges();
            return company;

        }

        private IQueryable<CompanyViewModel> AllCompany ()
        {
            return from entity in context.tbl_Company
                   select new CompanyViewModel
                   {
                       companyId = entity.CompanyId,
                       companyName = entity.CompanyName,
                       companyAddress = entity.CompanyAddress,
                       phoneNo = entity.PhoneNo,
                       email = entity.Email,
                       website = entity.Website,
                       companyLogo = entity.CompanyLogo,
                       isActive = entity.IsActive,
                       createdBy = "admin",
                       createdOn = DateTime.Now,
                       modifiedBy = "admin",
                       modifiedOn = DateTime.Now
                   };
        }

        public IEnumerable<CompanyViewModel> GetCompanyDetails ()
        {
            var data = AllCompany();
            return data.ToList();
        }

        public IQueryable<CompanyViewModel> GetCompanyById (int id)
        {
            var data = AllCompany().Where(c => c.companyId == id);
            return data;
        }

        public bool UpdateCompanyDetails (CompanyViewModel entity)
        {
            var data = (from c in context.tbl_Company where c.CompanyId == entity.companyId select c).SingleOrDefault();
            if(data != null)
            {
                data.CompanyId = entity.companyId;
                data.CompanyName = entity.companyName;
                data.CompanyAddress = entity.companyAddress;
                data.PhoneNo = entity.phoneNo;
                data.Email = entity.email;
                data.Website = entity.website;
                data.CompanyLogo = entity.companyLogo;
                data.IsActive = entity.isActive;
                data.ModifiedBy = "admin";
                data.ModifiedOn = DateTime.Now;
            };
            return context.SaveChanges() > 0;
        }
    }
}
