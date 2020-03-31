using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LogIt.WebMVC.Startup))]
namespace LogIt.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
