using System.Linq;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Helper;
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
                    if (cell.IsEmpty())
                    {
                        this.PublishWarning(column.GetErrorMessageForEmptyCell());
                    }
                    else
                    {
                        this.CheckCellContent(cell, column);
                    }
                }
            }
        }

        private void CheckCellContent(string cellContent, Column column)
        {
            if (!column.IsValidContent(cellContent, out var errorMessage))
            {
                this.PublishError(errorMessage);
            }
        }
    }
}