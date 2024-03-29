﻿using System.Linq;
using Alcuin.BDES.Interfaces;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class CellContentControlCommand : Command
    {
        public CellContentControlCommand(IMonitoringManager monitoringManager)
            : base(Step.DataAnalyzing, monitoringManager, 20)
        {
        }

        protected override void Process(ProcessingContext processingContext, Request request)
        {
            var columnsToCheck = processingContext.AvailableSheets
                .SelectMany(x => x.AvailableColumns);

            foreach (var column in columnsToCheck)
            {
                foreach (var cell in column.GetCells())
                {
                    if (!column.IsValidContent(cell, out var errorMessage))
                    {
                        this.PublishError(errorMessage);
                        break;
                    }
                }
            }
        }
    }
}