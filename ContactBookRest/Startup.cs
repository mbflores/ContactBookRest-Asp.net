using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactBookRest.Startup))]
namespace ContactBookRest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
