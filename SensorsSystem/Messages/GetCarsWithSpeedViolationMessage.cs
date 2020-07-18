using System;

namespace SensorsSystem.Messages
{
    public class GetCarsWithSpeedViolationMessage
    {
        public DateTime FixingDate { get; set; }

        public double SpeedBorder { get; set; }
    }
}
