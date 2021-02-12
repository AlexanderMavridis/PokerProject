using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PokerProject.Startup))]
namespace PokerProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
