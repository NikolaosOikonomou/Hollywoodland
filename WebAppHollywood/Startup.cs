using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppHollywood.Startup))]
namespace WebAppHollywood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
