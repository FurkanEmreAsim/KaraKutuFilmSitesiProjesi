using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebProgramlama.Startup))]
namespace WebProgramlama
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
