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
    public class MeasurementRepository: IMeasurementRepository
    {
        private PradadgeContext context;
        public MeasurementRepository (PradadgeContext context)
        {
            this.context = context;
        }

        public MeasurementViewModel AddMeasurement (MeasurementViewModel entity)
        {
            var data = new tbl_Measurement
            {
                UnitOfMeasurementId = entity.unitOfMeasurementId,
                UOM = entity.uom,
                IsActive = entity.isActive
            };

            context.tbl_Measurement.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<MeasurementViewModel> AllMeasurement()
        {
            return from entity in context.tbl_Measurement
                   select new MeasurementViewModel
                   {
                       unitOfMeasurementId = entity.UnitOfMeasurementId,
                       uom = entity.UOM,
                       isActive = entity.IsActive
                   };
        }

        public IEnumerable<MeasurementViewModel> GetMeasurement()
        {
            var data = AllMeasurement();
            return data.ToList();
        }

        public IQueryable<MeasurementViewModel> GetMeasurementById(int id)
        {
            var data = AllMeasurement().Where(d => d.unitOfMeasurementId == id);
            return data;
        }

        public bool UpdateMasurement (MeasurementViewModel entity)
        {
            var data = (from d in context.tbl_Measurement where d.UnitOfMeasurementId == entity.unitOfMeasurementId select d).SingleOrDefault();
            if(data != null)
            {
                data.UnitOfMeasurementId = entity.unitOfMeasurementId;
                data.UOM = entity.uom;
                data.IsActive = entity.isActive;
            }

            return context.SaveChanges() > 0;
        }
    }
}
