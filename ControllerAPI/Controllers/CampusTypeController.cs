using Application.DTOs.Campus;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces.ApplicationInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusTypeController : ControllerBase
    {
        private readonly IBaseService<CampusTypeEntity, CampusTypeEntity> baseService;

        public CampusTypeController(IBaseService<CampusTypeEntity, CampusTypeEntity> iBaseService)
        {
            baseService = iBaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await baseService.GetAll<CampusTypeEntity>();
            return Ok(res);
        }
    }
}
