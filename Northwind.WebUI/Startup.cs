using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Northwind.WebUI.Startup))]
namespace Northwind.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
