using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VXH.Startup))]
namespace VXH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
