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
    public class CustomerRepository: ICustomerRepository
    {
        private PradadgeContext context;
        public CustomerRepository(PradadgeContext context)
        {
            this.context = context;
        }

        public CustomerViewModel AddCustomer(CustomerViewModel entity)
        {
            var data = new tbl_Customer
            {
                CustomerId = entity.customerId,
                FirstName = entity.firstName,
                LastName = entity.lastName,
                OtherName = entity.otherName,
                PhoneNo = entity.phoneNo,
                Address = entity.address,
                Email = entity.email,
                AlternativeEmail = entity.alternativeEmail,
                AlternativePhoneNo = entity.alternativePhoneNo,
                LoyaltyCardNumber = entity.loyaltyCardNumber,
                IsActive = entity.isActive,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "admin"
            };            
            context.tbl_Customer.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<CustomerViewModel> AllCustomer()
        {
            return from entity in context.tbl_Customer
                   select new CustomerViewModel
                   {
                       customerId = entity.CustomerId,
                       firstName = entity.FirstName,
                       lastName = entity.LastName,
                       otherName = entity.OtherName,
                       phoneNo = entity.PhoneNo,
                       address = entity.Address,
                       email = entity.Email,
                       alternativeEmail = entity.AlternativeEmail,
                       alternativePhoneNo = entity.AlternativePhoneNo,
                       loyaltyCardNumber = entity.LoyaltyCardNumber,
                       isActive = entity.IsActive,
                       createdOn = DateTime.Now,
                       createdBy = "admin",
                       modifiedOn = DateTime.Now,
                       modifiedBy = "admin"

                   };
        }

        public IEnumerable<CustomerViewModel> GetCustomer()
        {
            var data = AllCustomer();
            return data.ToList();
        }

        public IQueryable<CustomerViewModel> GetCustomerById(int id)
        {
            var data = AllCustomer().Where(c => c.customerId == id);
            return data;
        }

        public bool UpdateCustomerDetails(CustomerViewModel entity)
        {
            var data = (from d in context.tbl_Customer where d.CustomerId == entity.customerId select d).SingleOrDefault();
            if (data != null)
            {
                data.CustomerId = entity.customerId;
                data.FirstName = entity.firstName;
                data.LastName = entity.lastName;
                data.OtherName = entity.otherName;
                data.PhoneNo = entity.phoneNo;
                data.Address = entity.address;
                data.Email = entity.email;
                data.AlternativeEmail = entity.alternativeEmail;
                data.AlternativePhoneNo = entity.alternativePhoneNo;
                data.LoyaltyCardNumber = entity.loyaltyCardNumber;
                data.IsActive = entity.isActive;
                data.ModifiedOn = DateTime.Now;
                data.ModifiedBy = "admin";
            };
            return context.SaveChanges() > 0;
        }
    }
}

