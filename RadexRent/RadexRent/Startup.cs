using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RadexRent.Startup))]
namespace RadexRent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
