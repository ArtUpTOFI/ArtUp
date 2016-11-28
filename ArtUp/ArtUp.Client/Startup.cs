using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtUp.Client.Startup))]
namespace ArtUp.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
