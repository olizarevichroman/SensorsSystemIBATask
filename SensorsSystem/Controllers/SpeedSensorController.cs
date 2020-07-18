using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SensorsSystem.DataLayer.Contracts;
using SensorsSystem.DataLayer.Models;
using SensorsSystem.Filters;
using SensorsSystem.Messages;

namespace SensorsSystem.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Route("[controller]")]
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

        [HttpPost]
        public async Task<SpeedSensorData> Create(SpeedSensorData data)
        {
            return await _repository.Create(data);
        }

        [HttpGet]
        [ServiceFilter(typeof(RestrictDataSelectionAttribute))]
        [Route("[action]")]
        public async Task<IEnumerable<SpeedSensorData>> GetCarsWithSpeedViolation([FromBody] GetCarsWithSpeedViolationMessage message)
        {
            var result = await _repository.FindAll(d => d.Date.Equals(message.FixingDate) && d.Speed > message.SpeedBorder);

            return result;
        }
    }
}
