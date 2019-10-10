using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface ICategoryRepository
    {
        CategoryViewModel AddCategory(CategoryViewModel entity);
        IEnumerable<CategoryViewModel> GetCategory();
        IQueryable<CategoryViewModel> GetCategoryById(int id);
        bool UpdateCategory(CategoryViewModel category);
    }
}
