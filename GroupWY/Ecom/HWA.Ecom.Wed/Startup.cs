using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HWA.Ecom.Wed.Startup))]
namespace HWA.Ecom.Wed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
