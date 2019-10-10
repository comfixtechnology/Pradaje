using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IVendorRepository
    {
        VendorViewModel AddVendor(VendorViewModel entity);
        IEnumerable<VendorViewModel> GetVendor();
        IQueryable<VendorViewModel> GetVendorById(int id);
        bool UpdateVendor(VendorViewModel entity);
    }
}
