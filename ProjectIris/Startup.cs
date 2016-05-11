using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectIris.Startup))]
namespace ProjectIris
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
