using System;
using System.ComponentModel.DataAnnotations;

namespace SensorsSystem.DataLayer.Models
{
    public class SpeedSensorData
    {
        public DateTime Date { get; set; }

        [Range(0, int.MaxValue)]
        public double Speed { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string CarNumber { get; set; }
    }
}
