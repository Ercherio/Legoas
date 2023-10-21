using Legoas.Context;
using Legoas.Models;

namespace Legoas.Repository.Data
{
    public class AccountOfficeRepository : GeneralRepository<MyContext, AccountOffice, string>
    {
        public AccountOfficeRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
