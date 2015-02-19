using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HangFire_Playground.Startup))]

namespace HangFire_Playground
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureHangfire(app);
        }
    }
}
