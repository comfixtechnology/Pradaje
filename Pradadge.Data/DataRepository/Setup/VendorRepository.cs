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
    public class VendorRepository: IVendorRepository
    {
        private PradadgeContext context;
        public VendorRepository (PradadgeContext context)
        {
            this.context = context;
        }

        public VendorViewModel AddVendor (VendorViewModel entity)
        {
            var data = new tbl_Vendor
            {
                VendorId = entity.vendorId,
                Vendor = entity.vendor,
                Address = entity.address,
                PhoneNo = entity.phoneNo,
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                ModifiedBy = "admin",
                ModifiedOn = DateTime.Now,
                IsActive = entity.isActive
                
            };

            context.tbl_Vendor.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<VendorViewModel> AllVendor()
        {
            return from entity in context.tbl_Vendor
                   select new VendorViewModel
                   {
                       vendorId = entity.VendorId,
                       vendor = entity.Vendor,
                       address = entity.Address,
                       phoneNo = entity.PhoneNo,
                       createdBy = "admin",
                       createdOn = DateTime.Now,
                       modifiedBy = "admin",
                       modifiedOn = DateTime.Now,
                       isActive = entity.IsActive                                        
                   };
        }

        public IEnumerable<VendorViewModel> GetVendor()
        {
            var data = AllVendor();
            return data;
        }

        public IQueryable<VendorViewModel> GetVendorById (int id)
        {
            var data = AllVendor().Where(c => c.vendorId == id);
            return data;
        }

        public bool UpdateVendor (VendorViewModel entity)
        {
            var data = (from c in context.tbl_Vendor where c.VendorId == entity.vendorId select c).SingleOrDefault();
            if(data != null)
            {
                data.VendorId = entity.vendorId;
                data.Vendor = entity.vendor;
                data.Address = entity.address;
                data.PhoneNo = entity.phoneNo;
                data.ModifiedBy = "admin";
                data.ModifiedOn = DateTime.Now;
                data.IsActive = entity.isActive;
            }

            return context.SaveChanges() > 0;
        }
    }
}
