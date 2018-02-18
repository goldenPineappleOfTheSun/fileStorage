using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Goldenpineappleofthesun.Web.Startup))]
namespace Goldenpineappleofthesun.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
