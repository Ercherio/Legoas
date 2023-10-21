using Legoas.Base;
using Legoas.Repository.Data;
using Legoas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LegoasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRolesController : BaseController<AccountRole, AccountRoleRepository, string>
    {
        public AccountRolesController(AccountRoleRepository repository) : base(repository)
        {
        }
    }
}
