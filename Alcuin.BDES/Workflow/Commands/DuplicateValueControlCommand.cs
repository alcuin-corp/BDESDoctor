﻿using System.Linq;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class DuplicateValueControlCommand : Command
    {
        public DuplicateValueControlCommand(IMonitoringManager monitoringManager)
            : base(Step.DataAnalyzing, monitoringManager, 10)
        {
        }

        protected override void Process(ProcessingContext processingContext, Request request)
        {
            var columnsToCheck = processingContext.AvailableSheets
                .SelectMany(x => x.AvailableColumns)
                .Where(x => !x.AllowDuplicateValues);

            foreach (var column in columnsToCheck)
            {
                var duplicatedValues = column.GetCells()
                    .Where(StringExtensions.IsNotEmpty)
                    .GroupBy(x => x)
                    .Where(g => g.Count() > 1);

                if (duplicatedValues.Any())
                {
                    this.PublishError($"Dans l'onglet '{column.Sheet.Name}' des doublons de '{column.Header}' ont été trouvés.");
                }
            }
        }
    }
}