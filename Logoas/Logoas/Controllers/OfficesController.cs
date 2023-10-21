using Legoas.Base;
using Legoas.Repository.Data;
using Legoas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LegoasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : BaseController<Office, OfficeRepository, int>
    {
        public OfficesController(OfficeRepository repository) : base(repository)
        {
        }
    }
}
