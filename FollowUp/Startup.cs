using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FollowUp.Startup))]
namespace FollowUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
