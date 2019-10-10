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
    public class ProductsRepository : IProductsRepository
    {
        private PradadgeContext context;
        public ProductsRepository (PradadgeContext context)
        {
            this.context = context;
        }

        public ProductViewModel AddProduct (ProductViewModel entity)
        {
            var data = new tbl_Product
            {
                ProductId = entity.productId,
                ProductName = entity.productName,
                ProductDescription = entity.productDescription,
                ProductCode = entity.productCode,
                ProductBarCode = entity.productBarCode, 
                Width = entity.width,
                Lenght = entity.lenght,
                Base_height = entity.base_height,
                //NetWeight = entity.netWeight,
                UnitOfMeasurementId = entity.unitOfMeasurementId,
                ApplyDimension = entity.applyDimension,
                Packing = entity.packing,
                BrandId = entity.brandId,
                CategoryId = entity.categoryId,
                IsActive = entity.isActive,
                UseDimensionInCalculation = entity.useDimensionInCalculation,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "admin"
            };

            context.tbl_Product.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<ProductViewModel> AllProduct()
        {
            return from entity in context.tbl_Product
                   select new ProductViewModel
                   {
                       productId = entity.ProductId,
                       productName = entity.ProductName + " " + entity.Width.ToString() + ("x" + entity.Lenght.ToString()),
                       productDescription = entity.ProductDescription,
                       productCode = entity.ProductCode,
                       productBarCode = entity.ProductBarCode, 
                       width = entity.Width,
                       lenght = entity.Lenght,
                       base_height = entity.Base_height,
                       useDimensionInCalculation = entity.UseDimensionInCalculation,
                       inSquareMeters =entity.InSquareMeters,
                       //netWeight = entity.NetWeight,
                       unitOfMeasurementId = entity.UnitOfMeasurementId,
                       uom = entity.tbl_Measurement.UOM,
                       applyDimension = entity.ApplyDimension,
                       packing = entity.Packing,
                       brandId = entity.BrandId,
                        brandName = entity.tbl_Brand.BrandName,
                        categoryName = entity.tbl_Category.CategoryName,
                       categoryId = entity.CategoryId,
                       isActive = entity.IsActive,
                       createdOn = entity.CreatedOn,
                       createdBy = entity.CreatedBy,
                       modifiedOn = DateTime.Now,
                       modifiedBy = "admin"
                   };
        }

        public IEnumerable<ProductViewModel> GetAllProducts ()
        {
            var data = AllProduct();
            return data.ToList();
        }

        public IQueryable<ProductViewModel> GetProductById (int id)
        {
            var data = AllProduct().Where(c => c.productId == id);
            return data;
        }

        public IQueryable<ProductViewModel> GetProductByCategory (int id)
        {
            var data = AllProduct().Where(c => c.categoryId == id);
            return data;
        }

        public IQueryable<ProductViewModel> GetProductByBrand (int id)
        {
            var data = AllProduct().Where(c => c.brandId == id);
            return data;
        }

        public bool UpdateProduct (ProductViewModel entity)
        {
            var data = (from d in context.tbl_Product where d.ProductId == entity.productId select d).SingleOrDefault();
            if(data != null)
            {
                data.ProductId = entity.productId;
                data.ProductName = entity.productName;
                data.ProductDescription = entity.productDescription;
                data.ProductCode = entity.productCode;
                data.ProductBarCode = entity.productBarCode; 
                data.Width = entity.width;
                data.Lenght = entity.lenght;
                data.Base_height = entity.base_height;
                //data.NetWeight = entity.netWeight;
                data.UnitOfMeasurementId = entity.unitOfMeasurementId;
                data.ApplyDimension = entity.applyDimension;
                data.Packing = entity.packing;
                data.BrandId = entity.brandId;
                data.CategoryId = entity.categoryId;
                data.IsActive = entity.isActive;
                data.ModifiedOn = DateTime.Now;
                data.ModifiedBy = "admin";
                data.UseDimensionInCalculation = entity.useDimensionInCalculation;
                
            };

            return context.SaveChanges() > 0;
        }

        public bool DeleteOrder (ProductViewModel entity)
        {
            var data = context.tbl_Product.SingleOrDefault(c => c.ProductId == entity.productId);
            if (data != null)
            {
                context.tbl_Product.Remove(data);
                context.SaveChanges();
            }
            return false;
        }

        public List<ProductFilter> ProductStockDetails(int productId)
        {
            var result = (from p in GetAllProducts()
                          join s in context.tbl_Stock on p.productId equals s.ProductId
                          where p.productId == productId
                          select new ProductFilter
                          {
                              deliveryDate = s.DeliveryDate,
                              price = s.SellingPrice,
                              productId = s.ProductId,
                              productName = p.productName+ " " + p.size,
                              qtyLeft = s.QuantitySupplied - s.QuantitySold,
                              stockId = s.StockId,
                              applyDimension = p.applyDimension
                          });
            return result.Where(c=> c.qtyLeft> 0).ToList();
        }
        //.Where(c => c.QtyLeft > 0)
        public List<ProductFilter> ProductSearch(string search)
        {
            var result = (from p in GetAllProducts()
                              // join s in context.tbl_Stock on p.productId equals s.ProductId
                          where p.productName.ToLower().Contains(search.ToLower()) || p.productBarCode.ToLower().Contains(search.ToLower())
                          select new ProductFilter
                          {
                              productId = p.productId,
                              productName = p.productName + " " + p.size,
                              count =  GetQuantityLeft(p.productId)
        });
            return result.Distinct().ToList();
        }

        private decimal GetQuantityLeft(int productId)
        {
            var stocksum = context.tbl_Stock
                       .Where(s => s.ProductId == productId);
            if (stocksum.Count() > 0)
            {
                return stocksum.Sum(c => c.QuantitySupplied - c.QuantitySold);
            }
            else
            {
                return 0;
            }
        }
    }
}
