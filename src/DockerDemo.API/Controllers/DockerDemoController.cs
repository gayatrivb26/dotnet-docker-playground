using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DockerDemo.API.Controllers
{
    [ApiController]
    [Route("api/docker")]
    public class DockerDemoController : ControllerBase
    {
        private static readonly DateTime _startTime = DateTime.UtcNow;

        // Health check
        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok(new
            {
                status = "Healthy",
                timestamp = DateTime.UtcNow
            });
        }

        // container runtime
        [HttpGet("time")]
        public IActionResult Uptine()
        {
            var uptime = DateTime.UtcNow - _startTime;

            return Ok(new
            {
                startedAt = _startTime,
                uptimeInSeconds = uptime.TotalSeconds
            });
        }

        // Environment variables
        [HttpGet("env")]
        public IActionResult EnvironmentVariables()
        {
            return Ok(new
            {
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
                customMessage = Environment.GetEnvironmentVariable("APP_MESSAGE")
            });
        }

        // CPU load simulation
        [HttpGet("load")]
        public IActionResult GenerateLoad()
        {
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 100_000_000; i++)
            {
                //
            }

            stopwatch.Stop();

            return Ok(new
            {
                message = "CPU load generated",
                timeTakenMs = stopwatch.ElapsedMilliseconds
            });
        }

        // Versioning
        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok(new
            {
                version = "v1.0.0",
                service = "DockerDemo.API"
            }); ;
        }
    }
}
