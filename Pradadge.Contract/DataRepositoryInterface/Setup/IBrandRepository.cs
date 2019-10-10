using Pradadge.Entities.Model;
using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
   public  interface  IBrandRepository
    {
        BrandViewModel AddBrand(BrandViewModel entity);
        IEnumerable<BrandViewModel> GetBrand();
        IQueryable<BrandViewModel> GetBrandById(int id);
        bool  UpdateBrand(BrandViewModel entity);

    }
}
