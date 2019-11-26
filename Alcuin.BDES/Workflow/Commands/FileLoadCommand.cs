using System.IO;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class FileLoadCommand : Command
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
