using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_MyTimeTracker.Startup))]
namespace MVC_MyTimeTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
