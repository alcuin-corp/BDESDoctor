using System.IO;
using System.IO.Abstractions;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Monitoring;
using Alcuin.BDES.Ninject;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class FileLoadCommand : Command
    {
        private readonly IFileSystem fileSystem;

        public FileLoadCommand(IMonitoringManager monitoringManager)
            : base(Steps.FileAnalyzing, monitoringManager, 2)
        {
            ServiceLocator.Resolve(out this.fileSystem);
        }

        protected override void Process(ProcessingContext processingContext)
        {
            var filePath = processingContext.FilePath;
            if (!this.fileSystem.File.Exists(filePath))
            {
                throw new ProcessingException("Le fichier n'exsite pas !", this.CurrentStep);
            }

            processingContext.Workbook = this.fileSystem.LoadWorkbook(processingContext.FilePath);
        }
    }
}
