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
    public class BankRepository: IBankRepository
    {
        private PradadgeContext context;
        public BankRepository(PradadgeContext context)
        {
            this.context = context;
        }

        public BanksViewModel AddBank (BanksViewModel entity)
        {
            var data = new tbl_Banks
            {
                BankId = entity.bankId,
                BankName = entity.bankName,
                IsActive = entity.isActive,
            };
            context.tbl_Banks.Add(data);
            context.SaveChanges();
            return entity;
            //if (context.SaveChanges() > 0)
            //{
            //    return entity;
            //}
            //else
            //{
            //    return null;
            //}

        }
        

        public List<BanksViewModel> GetAllBanks()
        {
            return context.tbl_Banks.Select(c => new BanksViewModel
            {
                bankId = c.BankId,
                bankName = c.BankName,
                isActive = c.IsActive
            }).ToList();
        }

        public IEnumerable<BanksViewModel> GetBank(int id)
        {
            var data = GetAllBanks().Where(c => c.bankId == id);
            return data;
        }

        public bool UpdateBank (BanksViewModel entity)
        {
            var data = (from d in context.tbl_Banks where d.BankId == entity.bankId select d).SingleOrDefault();
            if (data != null)
            {
                data.BankId = entity.bankId;
                data.BankName = entity.bankName;
                data.IsActive = entity.isActive;
                //data.CreatedBy = entity.createdBy;
                //data.CreatedOn = entity.createdOn;
                //data.ModifiedBy = entity.modifiedBy;
                //data.ModifiedOn = entity.modifiedOn;
            };
            return context.SaveChanges() > 0;
        }
    }
}
