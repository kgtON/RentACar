using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RadexRent.Models
{
    public class CarReservation
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartPlace { get; set; }
        public string EndPlace { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}