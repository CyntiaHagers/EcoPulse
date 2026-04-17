using Microsoft.AspNetCore.Mvc;
using EcoPulse.Api.Models;
using EcoPulse.Api.Services;

namespace EcoPulse.Api.Controllers
{
    [ApiController]
    [Route("devices")]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceService _deviceService;

        public DevicesController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var devices = _deviceService.Get();
            return Ok(devices);
        }
    }
}