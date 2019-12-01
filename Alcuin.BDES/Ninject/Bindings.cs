using System.IO.Abstractions;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Indicators.Dumper;
using Alcuin.BDES.Indicators.Parser.Raw;
using Alcuin.BDES.Interfaces;
using Alcuin.BDES.Monitoring;
using Alcuin.BDES.Workflow;
using Ninject.Modules;

namespace Alcuin.BDES.Ninject
{
    internal class Bindings : NinjectModule
    {
        public override void Load()
        {
            this.SingletonScopeBinding();

            this.Bind<IFileSystem>().To<FileSystem>();
            this.Bind<IMonitoringManager>().To<MonitoringManager>();
            this.Bind<IMonitoringDumper>().To<MonitoringDumper>();

            this.Bind<IWorkflow>().To<Workflow.Workflow>();
            this.Bind<IIndicatorDumper>().To<IndicatorDumper>();
            this.Bind<IRawIndicatorReader>().To<RawIndicatorReader>();
        }

        private void SingletonScopeBinding()
        {
            this.Bind<IColumnProviderFactory>().To<ColumnProviderFactory>()
                    .InSingletonScope();

            this.Bind<IColumnProvider>().To<EffectifColumnProvider>()
                .InSingletonScope()
                .Named(SheetName.Effectifs.ToString());

            this.Bind<IColumnProvider>().To<AbsenceColumnProvider>()
                .InSingletonScope()
                .Named(SheetName.Absences.ToString());

            this.Bind<IColumnProvider>().To<DiseaseColumnProvider>()
                .InSingletonScope()
                .Named(SheetName.Maladies.ToString());
        }
    }
}