using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SensorsSystem.DataLayer.Contracts;
using SensorsSystem.DataLayer.Models;
using SensorsSystem.Messages;

namespace SensorsSystem.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Route("[controller]/[action]")]
    public class SpeedSensorController : ControllerBase
    {

        private readonly ILogger<SpeedSensorController> _logger;
        private readonly IRepository<SpeedSensorData> _repository;

        public SpeedSensorController(
            ILogger<SpeedSensorController> logger,
            IRepository<SpeedSensorData> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IEnumerable<SpeedSensorData>> GetCarsWithSpeedViolation([FromBody] GetCarsWithSpeedViolationMessage message)
        {
            var result = await _repository.FindAll(d => d.Date.Equals(message.Date) && d.Speed > message.SpeedBorder);

            return result;
        }
    }
}
