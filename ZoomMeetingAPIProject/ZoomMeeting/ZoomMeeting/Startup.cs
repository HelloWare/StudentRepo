using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZoomMeeting.Startup))]
namespace ZoomMeeting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
