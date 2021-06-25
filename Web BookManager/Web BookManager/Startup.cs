using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_BookManager.Startup))]
namespace Web_BookManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
