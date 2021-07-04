using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MayBeYouMissSomeNews.Startup))]
namespace MayBeYouMissSomeNews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
