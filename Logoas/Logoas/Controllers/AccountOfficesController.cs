using Legoas.Base;
using Legoas.Repository.Data;
using Legoas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Legoas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountOfficesController : BaseController<AccountOffice, AccountOfficeRepository, string>
    {
        public AccountOfficesController(AccountOfficeRepository repository) : base(repository)
        {
        }
    }
}
