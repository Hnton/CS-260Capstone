using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PurchaseRequisition.Startup))]
namespace PurchaseRequisition
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
