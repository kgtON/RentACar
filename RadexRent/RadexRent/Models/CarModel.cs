using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadexRent.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public int ProductionYear { get; set; }
        public string Color { get; set; }
        public double EngineCapacity { get; set; }
        public string EngineType { get; set; }
        public int CarCapacity { get; set; }
    }
}