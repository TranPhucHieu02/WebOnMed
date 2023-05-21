using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBookingCare.Startup))]
namespace WebBookingCare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
