// <copyright file="Command.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal abstract class Command
    {
        public Command(Step currentphase, IMonitoringManager monitoringManager)
        {
            this.CurrentStep = currentphase;
            this.MonitoringManager = monitoringManager;
        }

        public Step CurrentStep { get; }

        protected IMonitoringManager MonitoringManager { get; }

        public abstract void Process(ProcessingContext processingContext);

        protected void PublishSucces(string succesMessage)
        {
            this.MonitoringManager.AppendMessage(MonitoringCode.Succes, succesMessage);
        }

        protected void PublishError(string errorMessage)
        {
            this.MonitoringManager.AppendMessage(MonitoringCode.Error, errorMessage);
        }

        protected void PublishWarning(string warningMessage)
        {
            this.MonitoringManager.AppendMessage(MonitoringCode.Warrning, warningMessage);
        }
    }
}
