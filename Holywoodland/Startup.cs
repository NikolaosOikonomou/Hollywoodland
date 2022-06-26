using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Holywoodland.Startup))]
namespace Holywoodland
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
