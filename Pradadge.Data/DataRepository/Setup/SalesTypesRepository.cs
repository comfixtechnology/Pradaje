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
    public class SalesTypesRepository : ISalesTypesRepository
    {
        private PradadgeContext context;
        public SalesTypesRepository (PradadgeContext context)
        {
            this.context = context;
        }

        public SalesTypeViewModel AddSalesType (SalesTypeViewModel entity)
        {
            var data = new tbl_SalesType
            {
                SalesTypeId = entity.salesTypeId,
                SalesType = entity.salesType
            };

            context.tbl_SalesType.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<SalesTypeViewModel> AllSalesTypes ()
        {
            return from entity in context.tbl_SalesType
                   select new SalesTypeViewModel
                   {
                       salesTypeId = entity.SalesTypeId,
                       salesType = entity.SalesType
                   };
        }

        public IEnumerable<SalesTypeViewModel> GetAllSalesTypes ()
        {
            var data = AllSalesTypes();
            return data.ToList();
        }

        public IQueryable<SalesTypeViewModel> GetSalesTypesById (int id)
        {
            var data = AllSalesTypes().Where(c => c.salesTypeId == id);
            return data;
        }

        public bool UpdateSalesType (SalesTypeViewModel entity)
        {
            var data = (from d in context.tbl_SalesType where d.SalesTypeId == entity.salesTypeId select d).SingleOrDefault();
            data = new tbl_SalesType
            {
                SalesTypeId = entity.salesTypeId,
                SalesType = entity.salesType
            };
            return context.SaveChanges() > 0;
        }
    }
}
