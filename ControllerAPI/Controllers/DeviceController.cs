using Application.DTOs.AreaCampusDTO;
using Application.DTOs.AreaDTO;
using Application.DTOs.DeviceDTO;
using Domain.Interfaces.AppicationInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DeviceController : ControllerBase
{
    private readonly IDeviceService deviceService;

    public DeviceController(IDeviceService ideviceService)
    {
        deviceService = ideviceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10,
        [FromQuery] int? campusID = null)
    {
        var res = await deviceService.GetDevices<DeviceDTO>(pageNumber, pageSize, campusID);
        return Ok(res);
    }

    // [HttpGet("details")]
    // public async Task<IActionResult> GetDetails(int id)
    // {
    //     var res = await deviceService.GetDetailsByID<AreaCampusGetDetailsDTO>(id);
    //     return Ok(res);
    // }

    [HttpPost]
    public async Task<IActionResult> Insert(DeviceDTO deviceDto)
    {
        var res = await deviceService.InsertSingleRecord(deviceDto);
        return StatusCode(201, res);
    }
    
    [HttpPost("report-device-error")]
    public async Task<IActionResult> ReportDeviceError(DeviceErrorReportDTO deviceErrorReportDto)
    {
        // var device = await deviceService.GetByID(deviceErrorReportDto.DeviceID);
        // var user = await userService.GetById(deviceErrorReportDto.UserID);
        //
        // if (device == null || user == null)
        // {
        //     return BadRequest("Invalid DeviceID or UserID.");
        // }
        //
        // // Insert device error report logic
        // var result = await deviceService.ReportDeviceError(deviceErrorReportDto);

        return StatusCode(201);
    }

    [HttpPut]
    public async Task<IActionResult> Update(DeviceDTO deviceDto)
    {
        var res = await deviceService.UpdateSingleRecord(deviceDto);
        return Ok(res);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int deviceId)
    {
        var deviceDto = new DeviceDTO()
        {
            DeviceID = deviceId
        };
        var res = await deviceService.Delete(deviceDto);
        return Ok(res);
    }
}