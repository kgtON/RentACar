using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadexRent.Models
{
    public class CarReservation
    {
        public int Id { get; set; }
        public string CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartPlace { get; set; }
        public string EndPlace { get; set; }
    }
}