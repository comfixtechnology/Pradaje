using Pradadge.ViewModel.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface ISectionRepository
    {
        SectionViewModel AddSection(SectionViewModel entity);
        IEnumerable<SectionViewModel> GetSection();
        IQueryable<SectionViewModel> GetSectionById(int id);
        bool UpdateSection(SectionViewModel entity);
    }
}
