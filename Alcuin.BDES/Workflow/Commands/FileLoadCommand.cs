using System.IO.Abstractions;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Interfaces;
using Alcuin.BDES.Ninject;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class FileLoadCommand : Command
    {
        private readonly IFileSystem fileSystem;

        public FileLoadCommand(IMonitoringManager monitoringManager)
            : base(Step.FileAnalyzing, monitoringManager, 2)
        {
            ServiceLocator.Resolve(out this.fileSystem);
        }

        protected override void Process(ProcessingContext processingContext, Request request)
        {
            var filePath = request.FilePath;
            if (!this.fileSystem.File.Exists(filePath))
            {
                throw new ProcessingException("Le fichier n'exsite pas !");
            }

            processingContext.Workbook = this.fileSystem.LoadWorkbook(request.FilePath);
        }
    }
}