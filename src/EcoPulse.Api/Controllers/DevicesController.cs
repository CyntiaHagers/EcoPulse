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

        // ✅ GET /devices
        [HttpGet]
        public IActionResult Get()
        {
            var devices = _deviceService.Get();
            return Ok(devices);
        }

        // ✅ POST /devices
        [HttpPost]
        public IActionResult Create([FromBody] Device device)
        {
            _deviceService.Create(device);

            return CreatedAtAction(
                nameof(Get),
                new { id = device.Id },
                device
            );
        }
    }
}