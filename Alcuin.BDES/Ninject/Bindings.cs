using System.IO.Abstractions;
using Alcuin.BDES.Monitoring;
using Ninject.Modules;

namespace Alcuin.BDES.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMonitoringManager>().To<MonitoringManager>();
            this.Bind<IFileSystem>().To<FileSystem>();
        }
    }
}
