using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface ICountryRepository
    {
        CountryViewModel AddCountry(CountryViewModel entity);
        IEnumerable<CountryViewModel> GetCountry();
        IQueryable<CountryViewModel> GetCountryById(int id);
        bool UpdateCountry(CountryViewModel entity);
    }
}
