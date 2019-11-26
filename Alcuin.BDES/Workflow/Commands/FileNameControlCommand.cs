// <copyright file="ControlCommand.cs" company="Alucin">
// Copyright (c) Alucin. All rights reserved.
// </copyright>

namespace Alcuin.BDES.Workflow.Commands
{
    using System;
    using System.IO;
    using Alcuin.BDES.Domain;
    using Alcuin.BDES.Monitoring;

    internal class FileNameControlCommand : Command
    {
        private const string ExpectedFileExtension = ".xlsx";

        public FileNameControlCommand(IMonitoringManager monitoringManager)
            : base(Step.FileAnalyzing, monitoringManager, 1)
        {
        }

        protected override void Process(ProcessingContext processingContext)
        {
            var currentExtension = Path.GetExtension(processingContext.FileName);
            if (!ExpectedFileExtension.Equals(currentExtension, StringComparison.OrdinalIgnoreCase))
            {
                throw new ProcessingException(
                    "le format du fichier chargé est incorrect." +
                    $" Veuillez vérifier qu’il est bien au format Excel avec l’extension {ExpectedFileExtension}", this.CurrentStep);
            }

            this.PublishSucces("Le format de fichier est correct.");
        }
    }
}
