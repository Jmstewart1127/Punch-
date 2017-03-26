using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeClock.Startup))]
namespace TimeClock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
