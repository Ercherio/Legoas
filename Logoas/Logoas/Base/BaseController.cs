using Legoas.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Legoas.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
   where Entity : class
   where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult Insert(Entity entity)
        {
            try
            {
                repository.Insert(entity); return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data berhasil di insert!"
                });
            }
            catch (Exception e) { 

                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = e.Message
                });
            }

        }

        [HttpGet]

        public ActionResult Get()
        {
            var temp = repository.Get();
            if (temp == null)
            {
                //return NotFound(temp);
                //return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "No result" });
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data Kosong",
                });
            }
            else
            {
                //return Ok(temp);
                //return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = temp });

                return Ok(new
                {
                    StatusCode = 200,
                    Message = "",
                    Data = temp
                });
            }
        }

        [HttpGet("{key}")]

        public ActionResult GetKey(Key key)
        {
            try
            {
                var temp = repository.Get(key);
                if (temp == null)
                {
                    //return NotFound(temp);
                    //return StatusCode((int)HttpStatusCode.NotFound, new { status = (int)HttpStatusCode.NotFound, data = "No result" });
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data tidak ditemukan",
                    });
                }
                else
                {
                    //return Ok(temp);
                    //return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = temp });
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "",
                        Data = temp
                    });
                }
            }
            catch {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Ada Kesalahan"
                });
            }

            
        }

        [HttpPut]

        public ActionResult Update(Entity entity)
        {
            try
            {
                var temp = repository.Update(entity);
                return Ok("Sukses Update Data");
                //return StatusCode((int)HttpStatusCode.OK, new { status = (int)HttpStatusCode.OK, data = "Sukses Update Data" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                //return StatusCode((int)HttpStatusCode.InternalServerError, new { Status = (int)HttpStatusCode.InternalServerError, Message = e.Message });
            }

        }

        [HttpDelete("{key}")]

        public ActionResult Delete(Key key)
        {
            try
            {
                var temp = repository.Delete(key);
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Sukses Delete Data"
                });
                //return StatusCode((int)HttpStatusCode.OK, new { status = HttpStatusCode.OK, data = "Sukses Delete Data" });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = e.Message
                });
                //return StatusCode((int)HttpStatusCode.InternalServerError, new { Status = (int)HttpStatusCode.InternalServerError, Message = e.Message });
            }
        }
    }
}
