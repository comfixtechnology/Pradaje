using Pradadge.Contract.DataRepositoryInterface.Setup;
using Pradadge.Entities.Model;
using Pradadge.ViewModel.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Data.DataRepository.Business
{
    public class DamagesRepositorys : IDamagesRepositorys
    {
        private PradadgeContext context;
        public DamagesRepositorys (PradadgeContext context)
        {
            this.context = context;
        }

        public DamagesViewModel AddDamages (DamagesViewModel entity)
        {
            var data = new tbl_Damages
            {
                DamagesId = entity.damagesId,
                ProductId = entity.productId,
                QuantityDamaged = entity.quantityDamaged,
                DamagedDate = DateTime.Now,
                Reason = entity.reason,
                StockId = entity.stockId,
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                ModifiedBy = "admin",
                ModifiedOn = DateTime.Now
            };

            context.tbl_Damages.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<DamagesViewModel> AllDamages ()
        {
            return from entity in context.tbl_Damages
                   select new DamagesViewModel
                   {
                       damagesId = entity.DamagesId,
                       productId = entity.ProductId,
                       productName = entity.tbl_Product.ProductName,
                       quantityDamaged = entity.QuantityDamaged,
                       damagedDate = DateTime.Now,
                       reason = entity.Reason,
                       stockId = entity.StockId,
                       stockCode = entity.tbl_Stock.StockCode,
                       createdBy = "admin",
                       createdOn = DateTime.Now,
                       modifiedBy = "admin",
                       modifiedOn = DateTime.Now
                   };
        }

        public IEnumerable<DamagesViewModel> GetDamagesEncured ()
        {
            var data = AllDamages();
            return data.ToList();
        }

        public IQueryable<DamagesViewModel> GetDamagesById (int id)
        {
            var data = AllDamages().Where(c => c.damagesId == id);
            return data;
        }

        public bool UpdateDamages (DamagesViewModel entity)
        {
            var data = (from d in context.tbl_Damages where d.DamagesId == entity.damagesId select d).SingleOrDefault();
            if(data != null)
            {
                data.DamagesId = entity.damagesId;
                data.ProductId = entity.productId;
                data.QuantityDamaged = entity.quantityDamaged;
                data.DamagedDate = DateTime.Now;
                data.Reason = entity.reason;
                data.StockId = entity.stockId;
                data.ModifiedBy = "admin";
                data.ModifiedOn = DateTime.Now;
            };
            return context.SaveChanges() > 0;
        }
    }
}
