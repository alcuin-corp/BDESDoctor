using System.IO.Abstractions;
using Alcuin.BDES.Indicators.Dumper;
using Alcuin.BDES.Monitoring;
using Alcuin.BDES.Workflow;
using Ninject.Modules;

namespace Alcuin.BDES.Ninject
{
    internal class Bindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMonitoringManager>().To<MonitoringManager>();
            this.Bind<IFileSystem>().To<FileSystem>();
            this.Bind<IMonitoringDumper>().To<MonitoringDumper>();
            this.Bind<IMonitoringManager>().To<MonitoringManager>();
            this.Bind<IWorkflow>().To<Workflow.Workflow>();
            this.Bind<IIndicatorDumper>().To<IndicatorDumper>();
        }
    }
}