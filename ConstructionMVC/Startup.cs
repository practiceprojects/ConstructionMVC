using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConstructionMVC.Startup))]
namespace ConstructionMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
