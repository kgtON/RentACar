using System;
using System.Collections.Generic;

namespace RadexRent.Models
{
    public class CarRent
    {
        public int Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public double Distance { get; set; }
        public double FuelWasted { get; set; }
        public double TotalCost { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}