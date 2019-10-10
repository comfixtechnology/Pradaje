using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IMeasurementRepository
    {
        MeasurementViewModel AddMeasurement(MeasurementViewModel entity);
        IEnumerable<MeasurementViewModel> GetMeasurement();
        IQueryable<MeasurementViewModel> GetMeasurementById(int id);
        bool UpdateMasurement(MeasurementViewModel entity);
    }
}
