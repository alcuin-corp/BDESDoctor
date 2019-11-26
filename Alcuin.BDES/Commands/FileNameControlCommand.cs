// <copyright file="ControlCommand.cs" company="Alucin">
// Copyright (c) Alucin. All rights reserved.
// </copyright>

namespace Alcuin.Parser.Commands
{
    using System;
    using System.IO;
    using Alcuin.Parser.Domain;
    using Alcuin.Parser.Monitoring;
    using Alcuin.Parser.Workflow;

    public class FileNameControlCommand : Command
    {
        private const string ExpectedFileExtension = ".xlsx";

        public FileNameControlCommand(IMonitoringManager monitoringManager)
            : base(Step.FileAnalyzing, monitoringManager)
        {
        }

        public override void Process(ProcessingContext processingContext)
        {
            var currentExtension = Path.GetExtension(processingContext.FileName);
            if (!ExpectedFileExtension.Equals(currentExtension, StringComparison.OrdinalIgnoreCase))
            {
                throw new ProcessingException(
                    "le format du fichier chargé est incorrect." +
                    $" Veuillez vérifier qu’il est bien au format Excel avec l’extension {ExpectedFileExtension}", this.CurrentStep);
            }

            this.MonitoringManager.PublishSuccess("Le format de fichier est correct.", this.CurrentStep);
        }
    }
}
