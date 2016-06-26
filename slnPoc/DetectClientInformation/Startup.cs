using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DetectClientInformation.Startup))]
namespace DetectClientInformation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
