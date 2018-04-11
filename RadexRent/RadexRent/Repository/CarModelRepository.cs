using RadexRent.Models;
using RadexRent.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadexRent.Repository
{
    public class CarModelRepository:AbstractRepository<CarModel>, ICarModelRepository
    {
    }
}