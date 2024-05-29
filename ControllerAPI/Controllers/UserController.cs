using Application.DTOs.DeviceDTO;
using Application.DTOs.UserDTO;
using Domain.Interfaces.AppicationInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService iUserService)
    {
        userService = iUserService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10,
        [FromQuery] string? keyword = null)
    {
        var res = await userService.GetUsers<UserDTO>(pageNumber, pageSize, keyword);
        return Ok(res);
    }

    // [HttpGet("details")]
    // public async Task<IActionResult> GetDetails(int id)
    // {
    //     var res = await userService.GetDetailsByID<AreaCampusGetDetailsDTO>(id);
    //     return Ok(res);
    // }

    [HttpPost]
    public async Task<IActionResult> Insert(DeviceDTO deviceDto)
    {
        var res = await userService.Insert(deviceDto);
        return StatusCode(201, res);
    }

    [HttpPut]
    public async Task<IActionResult> Update(DeviceDTO deviceDto)
    {
        var res = await userService.Update(deviceDto);
        return Ok(res);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int deviceId)
    {
        var deviceDto = new DeviceDTO()
        {
            DeviceID = deviceId
        };
        var res = await userService.Delete(deviceDto);
        return Ok(res);
    }
}