using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Suggestions.Startup))]
namespace Suggestions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
