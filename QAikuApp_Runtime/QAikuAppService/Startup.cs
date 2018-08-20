using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(QAikuAppService.Startup))]

namespace QAikuAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}