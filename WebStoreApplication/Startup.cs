using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebStoreApplication.Startup))]
namespace WebStoreApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
