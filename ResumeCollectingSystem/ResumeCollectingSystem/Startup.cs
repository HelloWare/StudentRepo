using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResumeCollectingSystem.Startup))]
namespace ResumeCollectingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
