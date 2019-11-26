// <copyright file="IndicatorComputeCommand.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using Alcuin.BDES.Domain.Columns;
using Alcuin.BDES.Indicators;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class IndicatorComputeCommand : Command
    {
        public IndicatorComputeCommand(IMonitoringManager monitoringManager)
            : base(Step.DataAnalyzing, monitoringManager)
        {
        }

        public override void Process(ProcessingContext processingContext)
        {
            foreach (var sheet in processingContext.AvailableSheets)
            {
                foreach (var row in sheet.GetRows())
                {
                    foreach (var indicator in sheet.Indicators)
                    {
                        var groupKey = indicator.GroupColumn.GetCleanCell(row);
                        var indicatorValue = indicator.GetGroupValue(groupKey);
                        if (indicator.IsInclud(row, processingContext.ReferenceYear))
                        {
                            indicatorValue.Increment();
                            if (indicator.AgregateFunction == AgregateFunction.Avg)
                            {
                                var value = decimal.Parse(indicator.ColumnToAgregate.GetCell(row));
                                indicatorValue.AddTotal(value);
                            }
                        }
                    }
                }
            }
        }
    }
}
