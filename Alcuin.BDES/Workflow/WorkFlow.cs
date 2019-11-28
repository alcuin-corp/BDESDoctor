// <copyright file="WorkFlow.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

namespace Alcuin.BDES.Workflow
{
    using System;
    using System.Collections.Generic;
    using Alcuin.BDES.Domain;
    using Alcuin.BDES.Monitoring;
    using Alcuin.BDES.Workflow.Commands;

    internal class Workflow : IWorkflow
    {
        public void Process(Request request)
        {
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
