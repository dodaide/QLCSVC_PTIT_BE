using Application.DTOs.Campus;
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
}