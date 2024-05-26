using Application.DTOs.AreaDTO;
using Application.DTOs.AreaCampusDTO;
using Domain.Entities;
using Domain.Interfaces.ApplicationInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IBaseService<Area, AreaCampus> baseService;
        public AreaController(IBaseService<Area, AreaCampus> iBaseService) 
        {
            baseService = iBaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await baseService.GetAll<AreaGetAllDTO>();
            return Ok(res);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var res = await baseService.GetDetailsByID<AreaCampusGetDetailsDTO>(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(AreaInsertDTO areaDTO)
        {
            var res = await baseService.Insert(areaDTO.Area, areaDTO.Details);
            return StatusCode(201, res);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AreaUpdateDTO areaDTO)
        {
            var res = await baseService.Update(areaDTO.Area, areaDTO.Details);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int areaID)
        {
            var areaDTO = new AreaDeleteDTO()
            {
                AreaID = areaID
            };
            var res = await baseService.Delete(areaDTO);
            return Ok(res);
        }
    }
}
