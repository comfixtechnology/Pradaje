using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface ICustomerRepository
    {
        CustomerViewModel AddCustomer(CustomerViewModel entity);
        IEnumerable<CustomerViewModel> GetCustomer();
        IQueryable<CustomerViewModel> GetCustomerById(int id);
        bool UpdateCustomerDetails(CustomerViewModel entity);
    }
}
