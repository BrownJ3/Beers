using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Beers.Startup))]
namespace Beers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
