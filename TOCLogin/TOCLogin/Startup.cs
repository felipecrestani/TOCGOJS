using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TOCLogin.Startup))]
namespace TOCLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
