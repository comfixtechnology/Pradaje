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
    public class BranchRepository : IBranchRepository

    {
        private PradadgeContext context;

        public BranchRepository(PradadgeContext context)
        {
            this.context = context;
        }

        public BranchViewModel AddBranch(BranchViewModel entity)
        {
            var data = new tbl_Branch
            {
                BranchId = entity.branchId,
                BranchName = entity.branchName,
                StateId = entity.stateId,
                CountryId = entity.countryId,
                BranchAddress = entity.branchAddress,
                ContactPerson = entity.contactPerson,
                PhoneNo = entity.phoneNo,
                Email = entity.email,
                IsStore = entity.isStore,
                IsWarehouse = entity.isWarehouse,
                IsActive = entity.isActive,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "admin"

            };
            context.tbl_Branch.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<BranchViewModel> AllBranch()
        {
            return from entity in context.tbl_Branch
                   select new BranchViewModel
                   {
                       branchId = entity.BranchId,
                       branchName = entity.BranchName,
                       stateId = entity.StateId,
                       stateName = entity.tbl_State.StateName,
                       countryId = entity.CountryId,
                       countryName = entity.tbl_Country.CountryName,
                       branchAddress = entity.BranchAddress,
                       contactPerson = entity.ContactPerson,
                       phoneNo = entity.PhoneNo,
                       email = entity.Email,
                       isStore = entity.IsStore,
                       isWarehouse = entity.IsWarehouse,
                       isActive = entity.IsActive,
                       createdOn = entity.CreatedOn,
                       createdBy = entity.CreatedBy,
                       modifiedOn = DateTime.Now,
                       modifiedBy = entity.ModifiedBy
                   };
        }

        public IEnumerable<BranchViewModel> GetBranch()
        {
            var data = AllBranch();
            return data.ToList();
        }

        public IQueryable<BranchViewModel> GetBranchById(int id)
        {
            var data = AllBranch().Where(c => c.branchId == id);
            return data;
        }

        public bool UpdateBranch(BranchViewModel branch)
        {
            var data = (from c in context.tbl_Branch where c.BranchId == branch.branchId select c).SingleOrDefault();
            if(data != null)
            {

                data.BranchName = branch.branchName;
                data.StateId = branch.stateId;
                data.CountryId = branch.countryId;
                data.BranchAddress = branch.branchAddress;
                data.ContactPerson = branch.contactPerson;
                data.PhoneNo = branch.phoneNo;
                data.Email = branch.email;
                data.IsStore = branch.isStore;
                data.IsWarehouse = branch.isWarehouse;
                data.IsActive = branch.isActive;
                data.ModifiedOn = DateTime.Now;
                data.ModifiedBy = "admin";
            }

            //var result = data;
            return context.SaveChanges() > 0;

        }
    }
}
