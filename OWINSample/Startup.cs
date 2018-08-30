using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OWINSample.Startup))]
namespace OWINSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
