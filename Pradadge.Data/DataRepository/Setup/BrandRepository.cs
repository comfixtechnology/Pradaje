using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.Data.DataRepository.Setup;
using Pradadge.Entities.Model;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Data.DataRepository.Setup
{
    
    public class BrandRepository : IBrandRepository
    {
        private PradadgeContext context;

        public BrandRepository(PradadgeContext context)
        {
            this.context = context;
        }

        public BrandViewModel AddBrand(BrandViewModel entity)
        {
            var data = new tbl_Brand()
            {
                BrandId = entity.brandId,
                BrandName = entity.brandName,
                IsActive = entity.isActive,
                 CreatedOn = entity.createdOn,
                 CreatedBy = entity.createdBy,
                  ModifiedOn = entity.modifiedOn,
                  ModifiedBy = entity.modifiedBy
            };
            context.tbl_Brand.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<BrandViewModel> AllBrand ()
        {


            return from entity in context.tbl_Brand select new BrandViewModel
                   {
                       brandId = entity.BrandId,
                       brandName = entity.BrandName,
                       isActive = entity.IsActive,
                       createdOn = entity.CreatedOn,
                       createdBy = entity.CreatedBy,
                       modifiedOn = entity.ModifiedOn,
                       modifiedBy = entity.ModifiedBy
                   };
        }

        public IEnumerable<BrandViewModel> GetBrand ()
        {
            var data = AllBrand();
            return data.ToList();
        }

        public IQueryable<BrandViewModel> GetBrandById (int id)
        {
            var data = AllBrand().Where(c => c.brandId == id);
            return data;
        }

        public bool UpdateBrand (BrandViewModel entity)
        {
            //var result = 0;
            var data = (from d in context.tbl_Brand where d.BrandId == entity.brandId select d).SingleOrDefault();
            if (data != null)
            {
                data.BrandName = entity.brandName;
                data.IsActive = entity.isActive;
                data.ModifiedOn = DateTime.Now;
                data.ModifiedBy = "admin";
            }
            return context.SaveChanges() > 0;
        }
        
    }
}
