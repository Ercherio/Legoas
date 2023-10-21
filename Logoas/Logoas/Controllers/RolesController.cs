using Legoas.Base;
using Legoas.Repository.Data;
using Legoas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Legoas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController<Role, RoleRepository, int>
    {
        public RolesController(RoleRepository repository) : base(repository)
        {
        }
    }
}
