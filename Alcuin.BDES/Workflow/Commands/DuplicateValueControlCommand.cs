// <copyright file="DuplicateValueControlCommand.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Linq;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class DuplicateValueControlCommand : Command
    {
        public DuplicateValueControlCommand(IMonitoringManager monitoringManager)
            : base(Step.DataAnalyzing, monitoringManager)
        {
        }

        public override void Process(ProcessingContext processingContext)
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
                    this.PublishError($"Dans l'onglet «{column.Sheet.Name}» des doublons de «{column.Header}» ont été trouvé. Veuillez vérifier qu’il n’y est pas de «{column.Header}» en double.");
                }
            }
        }
    }
}