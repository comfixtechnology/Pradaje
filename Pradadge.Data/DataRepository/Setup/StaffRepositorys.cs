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
    public class StaffRepositorys : IStaffRepositorys
    {
        private PradadgeContext context;
        public StaffRepositorys (PradadgeContext context)
        {
            this.context = context;
        }

        public StaffViewModel AddStaff (StaffViewModel entity)
        {
            var data = new tbl_Staff
            {
                StaffId = entity.staffId,
                FirstName = entity.firstName,
                LastName = entity.lastName,
                OtherName = entity.otherName,
                PhoneNo = entity.phoneNo,
                AlternativePhoneNo = entity.alternativePhoneNo,
                Address = entity.address,
                Email = entity.email,
                AlternativeEmail = entity.alternativeEmail,
                Designation = entity.designation,
                IsActive = entity.isActive,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin",
                ModifiedBy = "admin",
                ModifiedOn = DateTime.Now
            };

            context.tbl_Staff.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<StaffViewModel> AllStaff ()
        {
            return from entity in context.tbl_Staff
                   select new StaffViewModel
                   {
                       staffId = entity.StaffId,
                       firstName = entity.FirstName,
                       lastName = entity.LastName,
                       otherName = entity.OtherName,
                       phoneNo = entity.PhoneNo,
                       alternativePhoneNo = entity.AlternativePhoneNo,
                       address = entity.Address,
                       email = entity.Email,
                       alternativeEmail = entity.AlternativeEmail,
                       isActive = entity.IsActive,
                       designation = entity.Designation,
                       createdOn = entity.CreatedOn,
                       createdBy = entity.CreatedBy,
                       modifiedBy = "admin",
                       modifiedOn = DateTime.Now
                   };
        }

        public IEnumerable<StaffViewModel> GetAllStaff ()
        {
            var data = AllStaff();
            return data.ToList();
        }

        public IQueryable<StaffViewModel> GetStaffById (int id)
        {
            var data = AllStaff().Where(c => c.staffId == id);
            return data;
        }

        public bool UpdateStaff (StaffViewModel entity)
        {
            var data = (from d in context.tbl_Staff where d.StaffId == entity.staffId select d).SingleOrDefault();
            if (data != null)
            {
                data.StaffId = entity.staffId;
                data.FirstName = entity.firstName;
                data.LastName = entity.lastName;
                data.OtherName = entity.otherName;
                data.PhoneNo = entity.phoneNo;
                data.AlternativePhoneNo = entity.alternativePhoneNo;
                data.Address = entity.address;
                data.Email = entity.email;
                data.AlternativeEmail = entity.alternativeEmail;
                data.Designation = entity.designation;
                data.IsActive = entity.isActive;
                data.ModifiedBy = "admin";
                data.ModifiedOn = DateTime.Now;
            };

             return context.SaveChanges() > 0;
        }
    }
}
