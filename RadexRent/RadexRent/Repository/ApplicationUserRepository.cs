using RadexRent.Models;
using RadexRent.Repository.Interfacecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadexRent.Repository
{
    public class ApplicationUserRepository: AbstractRepository<ApplicationUser>, IApplicationUserRepository
    {
    }
}