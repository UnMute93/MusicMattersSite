using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicMattersSite.Startup))]
namespace MusicMattersSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
