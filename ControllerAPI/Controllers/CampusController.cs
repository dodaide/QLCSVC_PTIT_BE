using Application.DTOs.AreaDTO;
using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.ApplicationInterfaces;
using Domain.Entities;
using Domain.Interfaces.AppicationInterfaces;
using Application.DTOs.Campus;

namespace ControllerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusController : ControllerBase
    {
        private readonly ICampusService campusService;
        public CampusController(ICampusService iCampusService)
        {
            campusService = iCampusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await campusService.GetAll<CampusGetAllDTO>();
            return Ok(res);
        }
    }
}
