// <copyright file="Command.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alcuin.BDES.Commands
{
    using System;
    using Alcuin.Parser.Domain;
    using Alcuin.Parser.Monitoring;
    using Alcuin.Parser.Workflow;

    public abstract class Command
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
            this.MonitoringManager.PublishSuccess(succesMessage, this.CurrentStep);
        }

        protected void PublishError(string errorMessage)
        {
            this.MonitoringManager.PublishError(errorMessage, this.CurrentStep);
        }

        protected void PublishWarning(string warningMessage)
        {
            this.MonitoringManager.PublishWarning(warningMessage, this.CurrentStep);
        }
    }
}
