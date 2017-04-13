using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Statecraft.Startup))]
namespace Statecraft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
