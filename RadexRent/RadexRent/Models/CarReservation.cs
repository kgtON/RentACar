using System;
using System.Collections.Generic;

namespace RadexRent.Models
{
    public class CarReservation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartPlace { get; set; }
        public string EndPlace { get; set; }

        public virtual ICollection<CarModel> CarIds { get; set; }
    }
}