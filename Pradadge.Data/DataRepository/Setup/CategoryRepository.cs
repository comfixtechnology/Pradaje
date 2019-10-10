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
    public class CategoryRepository: ICategoryRepository
    {
        private PradadgeContext context;
        public CategoryRepository (PradadgeContext context)
        {
            this.context = context;
        }

        public CategoryViewModel AddCategory (CategoryViewModel entity)
        {
            var data = new tbl_Category
            {
                //CategoryId = entity.categoryId,
                CategoryName = entity.categoryName,
                IsActive = entity.isActive,
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                ModifiedBy = "admin",
                ModifiedOn = DateTime.Now

            };

            context.tbl_Category.Add(data);
            context.SaveChanges();
            return entity;
        }

        public IQueryable<CategoryViewModel> AllCategory()
        {
            return from entity in context.tbl_Category
                   select new CategoryViewModel
                   {
                       categoryId = entity.CategoryId,
                       categoryName = entity.CategoryName,
                       isActive = entity.IsActive,
                       createdOn = entity.CreatedOn,
                       createdBy = entity.CreatedBy,
                       modifiedOn = DateTime.Now,
                       modifiedBy = "admin"
                   };
        }

        public IEnumerable<CategoryViewModel> GetCategory()
        {
            var data = AllCategory();

            return data.ToList();
        }

        public IQueryable<CategoryViewModel> GetCategoryById(int id)
        {
            var data = AllCategory().Where(c => c.categoryId == id);
            return data;
        }

        public bool UpdateCategory(CategoryViewModel category)
        {
            var data = (from c in context.tbl_Category where c.CategoryId == category.categoryId select c).SingleOrDefault();
            if (data != null)
            {
                data.CategoryId = category.categoryId;
                data.CategoryName = category.categoryName;
                data.IsActive = category.isActive;
                data.ModifiedOn = DateTime.Now;
                data.ModifiedBy = "admin";
            }
            return context.SaveChanges() > 0;
        }
    }
}

