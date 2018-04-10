using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadexRent.Models
{
    public class CarRents
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public double Distance { get; set; }
        public double FuelWasted { get; set; }
        public double TotalCost { get; set; }
    }
}