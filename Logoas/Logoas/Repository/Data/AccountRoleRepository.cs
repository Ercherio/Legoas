using Legoas.Context;
using Legoas.Models;

namespace Legoas.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<MyContext, AccountRole, string>
    {
        public AccountRoleRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
