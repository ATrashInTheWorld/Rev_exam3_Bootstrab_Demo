using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DEMO_4.Startup))]
namespace DEMO_4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
