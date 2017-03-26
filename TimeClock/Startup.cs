using Microsoft.Owin;
using Owin;
using System.Web.Services.Description;
using TimeClock.Models;

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
