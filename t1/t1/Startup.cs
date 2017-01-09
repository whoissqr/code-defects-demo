using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(t1.Startup))]
namespace t1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
