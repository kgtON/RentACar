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
        public EnumCompany Company { get; set; }
        public int ProductionYear { get; set; }
        public string Color { get; set; }
        public double EngineCapacity { get; set; }
        public EnumEngine EngineType { get; set; }
        public int CarCapacity { get; set; }
    }
}