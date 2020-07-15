using System;

namespace SensorsSystem.DataLayer.Models
{
    public class SpeedSensorData
    {
        public DateTime Date { get; set; }
        public double Speed { get; set; }
        public string CarNumber { get; set; }
    }
}
