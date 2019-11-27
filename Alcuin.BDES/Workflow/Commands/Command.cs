// <copyright file="Command.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal abstract class Command
    {
        public Command(string currentphase, IMonitoringManager monitoringManager, int progressRate)
        {
            this.CurrentStep = currentphase;
            this.MonitoringManager = monitoringManager;
            this.ProgressRate = progressRate;
        }

        public int ProgressRate { get; }

        public string CurrentStep { get; }

        protected IMonitoringManager MonitoringManager { get; }

        public virtual void Execute(ProcessingContext processingContext)
        {
            processingContext.CurrentStep = this.CurrentStep;
            this.Process(processingContext);
            processingContext.ProgressRate = this.ProgressRate;
        }

        protected abstract void Process(ProcessingContext processingContext);

        protected void PublishSucces(string succesMessage)
        {
            this.MonitoringManager.AppendMessage(MonitoringCodes.Succes, succesMessage);
        }

        protected void PublishError(string errorMessage)
        {
            this.MonitoringManager.AppendMessage(MonitoringCodes.Error, errorMessage);
        }

        protected void PublishWarning(string warningMessage)
        {
            this.MonitoringManager.AppendMessage(MonitoringCodes.Warrning, warningMessage);
        }
    }
}
