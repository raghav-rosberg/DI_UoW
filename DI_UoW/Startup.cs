using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DI_UoW.Startup))]
namespace DI_UoW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
