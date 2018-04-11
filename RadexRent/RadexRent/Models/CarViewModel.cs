using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadexRent.Models
{
    public class CarViewModel
    {
        public CarModel carModel { get; set; }
        public SelectList ListUsers { get; set; }
    }
}