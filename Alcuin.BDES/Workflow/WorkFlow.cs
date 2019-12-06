using System;
using System.Collections.Generic;
using System.Threading;
using Alcuin.BDES.Interfaces;
using Alcuin.BDES.Monitoring;
using Alcuin.BDES.Workflow.Commands;

namespace Alcuin.BDES.Workflow
{
    internal class Workflow : IWorkflow
    {
        public void Process(Request request)
        {
            var frenchCulture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = frenchCulture;
            Thread.CurrentThread.CurrentUICulture = frenchCulture;

            var monitoringManager = new MonitoringManager(request);
            var processingContext = new ProcessingContext();
            try
            {
                foreach (var command in this.GetCommands(monitoringManager))
                {
                    command.Execute(processingContext, request);
                }
            }
            catch (Exception exception)
            {
                request.IsFailed = true;
                request.Exception = exception;

                if (exception is ProcessingException)
                {
                    monitoringManager.Append(exception);
                }
            }
            finally
            {
                processingContext.Workbook?.Dispose();
                monitoringManager.Dump();
                request.IsFinished = true;
            }
        }

        private List<Command> GetCommands(IMonitoringManager monitoringManager)
        {
            return new List<Command>
            {
                new FileNameControlCommand(monitoringManager),
                new FileLoadCommand(monitoringManager),
                new SheetControlCommand(monitoringManager),
                new ColumnControlCommand(monitoringManager),
                new DuplicateValueControlCommand(monitoringManager),
                new CellContentControlCommand(monitoringManager),
                new IndicatorLoadCommand(monitoringManager),
                new IndicatorComputeCommand(monitoringManager),
                new OutputGenerateCommand(monitoringManager)
            };
        }
    }
}