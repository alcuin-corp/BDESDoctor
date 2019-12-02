using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Indicators;
using Alcuin.BDES.Interfaces;
using Alcuin.BDES.Ninject;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class IndicatorLoadCommand : Command
    {
        private readonly IndicatorProvider indicatorProvider;

        public IndicatorLoadCommand(IMonitoringManager monitoringManager)
            : base(Step.IndicatorComputing, monitoringManager, 25)
        {
            ServiceLocator.Resolve(out this.indicatorProvider);
        }

        public override void Execute(ProcessingContext processingContext, Request request)
        {
            if (request.PublishedMessages.TryGetValue(MonitoringType.Error, out var errors) && errors.Any())
            {
                throw new ProcessingException("Le processus ne peut pas continuer à cause des erreurs detectées");
            }

            base.Execute(processingContext, request);
        }

        protected override void Process(ProcessingContext processingContext, Request request)
        {
            var allIndicators = this.indicatorProvider.Load();
            foreach (var sheet in processingContext.AvailableSheets)
            {
                var availableIndicators = new List<Indicator>();
                var availableColumn = sheet.AvailableColumns;

                if (allIndicators.TryGetValue(sheet.SheetName, out var listOfIndicator))
                {
                    foreach (var indicator in listOfIndicator)
                    {
                        if (indicator.UsedColumns.All(x => sheet.AvailableColumns.Contains(x)))
                        {
                            sheet.Indicators.Add(indicator);
                        }
                        else
                        {
                            this.PublishWarning($"L'indicateur '{indicator.Name}' ne sera pas calculé.");
                        }
                    }
                }
            }
        }
    }
}