// <copyright file="OutputGenerateCommand.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.IO;
using System.Linq;
using Alcuin.BDES.Indicators.Dumper;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class OutputGenerateCommand : Command
    {
        private readonly IIndicatorDumper indicatorDumper;

        public OutputGenerateCommand(IMonitoringManager monitoringManager, IIndicatorDumper indicatorDumper)
            : base(Step.DataAnalyzing, monitoringManager, 95)
        {
            this.indicatorDumper = indicatorDumper;
        }

        protected override void Process(ProcessingContext processingContext)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(processingContext.FileName);
            var workingDirectory = Path.GetDirectoryName(processingContext.FilePath);
            var targetFilePath = Path.Combine(workingDirectory, $"{fileNameWithoutExtension}-Output.xlsx");
            var allIndicators = processingContext.AvailableSheets.SelectMany(x => x.Indicators);
            this.indicatorDumper.Dump(allIndicators, targetFilePath);
        }
    }
}
