using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityTestWebApp.Startup))]
namespace IdentityTestWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
