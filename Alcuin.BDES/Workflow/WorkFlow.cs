// <copyright file="WorkFlow.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

namespace Alcuin.BDES.Workflow
{
    using System;
    using System.Collections.Generic;
    using Alcuin.BDES.Domain;
    using Alcuin.BDES.Indicators.Dumper;
    using Alcuin.BDES.Monitoring;
    using Alcuin.BDES.Workflow.Commands;

    internal class Workflow
    {
        private IMonitoringManager monitoringManager;
        private List<Command> commands;

        public Workflow(Request request)
        {
            this.ProcessingContext = new ProcessingContext(request);
            this.monitoringManager = new MonitoringManager(request);
            this.InitilizeWorkflow();
        }

        public ProcessingContext ProcessingContext { get; }

        public void Process()
        {
            try
            {
                foreach (var command in this.commands)
                {
                    command.Execute(this.ProcessingContext);
                }
            }
            catch (ProcessingException processingEx)
            {
                this.ProcessingContext.IsFailed = true;
                this.ProcessingContext.ProcessingException = processingEx;
                this.monitoringManager.AppendMessage(MonitoringCode.Error, processingEx.Message);
            }
            catch (Exception ex)
            {
                this.ProcessingContext.IsFailed = true;
            }
            finally
            {

                this.ProcessingContext.Request.RaiseProcessFinished();
            }
        }

        private void InitilizeWorkflow()
        {
            this.commands = new List<Command>
            {
                new FileNameControlCommand(this.monitoringManager),
                new FileLoadCommand(this.monitoringManager),
                new SheetControlCommand(this.monitoringManager),
                new ColumnControlCommand(this.monitoringManager),
                new DuplicateValueControlCommand(this.monitoringManager),
                new CellContentControlCommand(this.monitoringManager),
                new IndicatorLoadCommand(this.monitoringManager),
                new IndicatorComputeCommand(this.monitoringManager),
                new OutputGenerateCommand(this.monitoringManager, new IndicatorDumper())
            };
        }
    }
}
