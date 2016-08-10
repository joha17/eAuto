using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eAuto.Startup))]
namespace eAuto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
