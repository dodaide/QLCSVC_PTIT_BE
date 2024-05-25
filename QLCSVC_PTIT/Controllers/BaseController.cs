using Domain.Entities;
using Domain.Interfaces.BLInterfaces;
using Domain.Interfaces.DLInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseController<T> : ControllerBase
    {
        protected IBaseBL<T> baseBL;
        protected IBaseDL<T> baseDL;

        public BaseController(IBaseBL<T> iBaseBL, IBaseDL<T> iBaseDL)
        {
            baseBL = iBaseBL;
            baseDL = iBaseDL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await baseDL.GetAll();
            return Ok(res);    
        }

        [HttpPost]
        public async Task<IActionResult> Insert(T t)
        {
            var res = await baseBL.Insert(t);
            return StatusCode(201, res);
        }

        [HttpPut]
        public async Task<IActionResult> Update(T t)
        {
            var res = await baseBL.Update(t);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await baseDL.Delete(id);
            return Ok(res);
        }
    }
}
