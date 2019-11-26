// <copyright file="FileLoadCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alcuin.BDES.Commands
{
    using System.IO;
    using Alcuin.Parser.Domain;
    using Alcuin.Parser.Monitoring;
    using Alcuin.Parser.Workflow;

    public class FileLoadCommand : Command
    {
        public FileLoadCommand(IMonitoringManager monitoringManager)
            : base(Step.FileAnalyzing, monitoringManager)
        {
        }

        public override void Process(ProcessingContext processingContext)
        {
            var filePath = processingContext.FilePath;
            if (!File.Exists(filePath))
            {
                throw new ProcessingException("Le fichier n'exsite pas !", this.CurrentStep);
            }

            processingContext.Workbook = new Aspose.Cells.Workbook(filePath);
        }
    }
}
