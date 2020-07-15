using System;

namespace SensorsSystem.Messages
{
    public class GetCarsWithSpeedViolationMessage
    {
        public DateTime Date { get; set; }
        public double SpeedBorder { get; set; }
    }
}
