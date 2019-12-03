﻿using System.IO;
using System.Linq;
using Alcuin.BDES.Indicators.Dumper;
using Alcuin.BDES.Interfaces;
using Alcuin.BDES.Ninject;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class OutputGenerateCommand : Command
    {
        private readonly IIndicatorDumper indicatorDumper;

        public OutputGenerateCommand(IMonitoringManager monitoringManager)
            : base(Step.OutputGeneration, monitoringManager, 98)
        {
            ServiceLocator.Resolve(out this.indicatorDumper);
        }

        protected override void Process(ProcessingContext processingContext, Request request)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(request.FilePath);
            var workingDirectory = Path.GetDirectoryName(request.FilePath);
            var targetFilePath = Path.Combine(workingDirectory, $"{fileNameWithoutExtension}-output.xls");
            var allIndicators = processingContext.AvailableSheets.SelectMany(x => x.Indicators);
            this.indicatorDumper.Dump(allIndicators, request.ReferenceYear, targetFilePath);
            request.OutputFilePath = targetFilePath;
        }
    }
}