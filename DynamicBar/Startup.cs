using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicBar.Startup))]
namespace DynamicBar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
