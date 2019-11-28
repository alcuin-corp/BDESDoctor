// <copyright file="Command.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal abstract class Command
    {
        public Command(Step currentphase, IMonitoringManager monitoringManager, int progressRate)
        {
            this.CurrentStep = currentphase;
            this.MonitoringManager = monitoringManager;
            this.ProgressRate = progressRate;
        }

        public int ProgressRate { get; }

        public Step CurrentStep { get; }

        protected IMonitoringManager MonitoringManager { get; }

        public virtual void Execute(ProcessingContext processingContext, Request request)
        {
            request.CurrentStep = this.CurrentStep;
            this.Process(processingContext, request);
            request.ProgressRate = this.ProgressRate;
        }

        protected abstract void Process(ProcessingContext processingContext, Request request);

        protected void PublishSucces(string succesMessage)
        {
            this.MonitoringManager.AppendMessage(MonitoringType.Succes, succesMessage);
        }

        protected void PublishError(string errorMessage)
        {
            this.MonitoringManager.AppendMessage(MonitoringType.Error, errorMessage);
        }

        protected void PublishWarning(string warningMessage)
        {
            this.MonitoringManager.AppendMessage(MonitoringType.Warrning, warningMessage);
        }
    }
}
