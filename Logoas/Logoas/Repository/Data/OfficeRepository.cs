using Legoas.Context;
using Legoas.Models;

namespace Legoas.Repository.Data
{
    public class OfficeRepository : GeneralRepository<MyContext, Office, int>
    {
        public OfficeRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
