using Application.DTOs.AreaDTO;
using Application.DTOs.Campus;
using Domain.Entities;
using Domain.Interfaces.AppicationInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers;

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

    [HttpPost]
    public async Task<IActionResult> Insert(CampusInsertDTO dto)
    {
        var res = await campusService.Insert(dto);
        return Ok(res);
    }

    [HttpPut]
    public async Task<IActionResult> Update(CampusUpdateDTO dto)
    {
        var res = await campusService.Update(dto);
        return Ok(res);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int campusID)
    {
        var campusDTO = new CampusDeleteDTO
        {
            CampusID = campusID
        };
        var res = await campusService.Delete(campusDTO);
        return Ok(res);
    }
}