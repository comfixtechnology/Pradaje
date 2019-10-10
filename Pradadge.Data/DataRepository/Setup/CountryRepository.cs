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
    public class CountryRepository: ICountryRepository
    {
        private PradadgeContext context;
        public CountryRepository (PradadgeContext context)
        {
            this.context = context;
        }

        public CountryViewModel AddCountry(CountryViewModel entity)
        {
            var data = new tbl_Country
            {
                CountryId = entity.countryId,
                CountryName = entity.countryName,
                IsActive = entity.isActive,
                CreatedBy = "admin",
                CreatedOn = DateTime.Now,
                ModifiedBy = "admin",
                ModifiedOn = DateTime.Now
            };

            context.tbl_Country.Add(data);
            context.SaveChanges();
            return entity;
        }

        private IQueryable<CountryViewModel> AllCountry()
        {
            return from entity in context.tbl_Country
                   select new CountryViewModel
                   {
                       countryId = entity.CountryId,
                       countryName = entity.CountryName,
                       isActive = entity.IsActive,
                       createdBy = "admin",
                       createdOn = DateTime.Now,
                       modifiedBy = "admin",
                       modifiedOn = DateTime.Now
                   };
        }

        public IEnumerable<CountryViewModel> GetCountry()
        {
            var data = AllCountry();
            return data.ToList();
        }

        public IQueryable<CountryViewModel> GetCountryById (int id)
        {
            var data = AllCountry().Where(d => d.countryId == id);
            return data;
        }

        public bool UpdateCountry(CountryViewModel entity)
        {
            var data = (from d in context.tbl_Country where d.CountryId == entity.countryId select d).SingleOrDefault();
            if(data != null)
            {
                data.CountryId = entity.countryId;
                data.CountryName = entity.countryName;
                data.IsActive = entity.isActive;
                data.ModifiedBy = "admin";
                data.ModifiedOn = DateTime.Now;
            }
            return context.SaveChanges() > 0;
        }
    }
}
