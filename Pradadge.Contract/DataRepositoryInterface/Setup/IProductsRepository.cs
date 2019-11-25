using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IProductsRepository
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        ProductViewModel AddProduct(ProductViewModel entity);
        IQueryable<ProductViewModel> GetProductById(int id);
        IQueryable<ProductViewModel> GetProductByCategory(int id);
        IQueryable<ProductViewModel> GetProductByBrand(int id);
        bool UpdateProduct(ProductViewModel entity);
        bool DeleteOrder(ProductViewModel entity);
        List<ProductFilter> ProductSearch(string search);
        List<ProductFilter> ProductSort(string search);
        List<ProductFilter> ProductStockDetails(int productId);
    }
}
