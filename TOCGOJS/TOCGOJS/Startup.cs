using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TOCGOJS.Startup))]
namespace TOCGOJS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
