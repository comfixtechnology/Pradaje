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
    public class SectionRepository: ISectionRepository
    {
        private PradadgeContext context;
        public SectionRepository (PradadgeContext context)
        {
            this.context = context;
        }

        public SectionViewModel AddSection (SectionViewModel entity)
        {
            var data = new tbl_Section
            {
                SectionId = entity.sectionId,
                Section = entity.section,
                IsActive = entity.isActive,
                CreatedOn = DateTime.Now,
                CreatedBy = "admin",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "admin"
            };

            context.tbl_Section.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<SectionViewModel> AllSection()
        {
            return from Entity in context.tbl_Section
                   select new SectionViewModel
                   {
                       sectionId = Entity.SectionId,
                       section = Entity.Section,
                       isActive = Entity.IsActive,
                       createdOn = DateTime.Now,
                       createdBy = "admin",
                       modifiedOn = DateTime.Now,
                       modifiedBy = "admin"
                   };
        }

        public IEnumerable<SectionViewModel> GetSection()
        {
            var data = AllSection();
            return data.ToList();

        }

        public IQueryable<SectionViewModel> GetSectionById (int id)
        {
            var data = AllSection().Where(c => c.sectionId == id);
            return data;
        }

        public bool UpdateSection(SectionViewModel entity)
        {
            var data = (from c in context.tbl_Section where c.SectionId == entity.sectionId select c).SingleOrDefault();
            if (data != null)
            {
                data.SectionId = entity.sectionId;
                data.Section = entity.section;
                data.IsActive = entity.isActive;
                data.CreatedBy = "admin";
                data.CreatedOn = DateTime.Now;
                data.ModifiedBy = "admin";
                data.ModifiedOn = DateTime.Now;
            }
            return context.SaveChanges() > 0;

        }
    }
}
