using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S00153208Rad301MVC1.Startup))]
namespace S00153208Rad301MVC1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
