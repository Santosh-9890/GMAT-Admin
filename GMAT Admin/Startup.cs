using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GMAT_Admin.Startup))]
namespace GMAT_Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
