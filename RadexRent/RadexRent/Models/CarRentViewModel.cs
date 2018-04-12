using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadexRent.Models
{
    public class CarRentViewModel
    {
        public CarRent carRent { get; set; }
        public Guid UserID { get; set; }
        public SelectList ListUsers { get; set; }
    }
}