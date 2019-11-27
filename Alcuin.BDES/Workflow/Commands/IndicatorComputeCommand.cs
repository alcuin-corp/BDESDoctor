// <copyright file="IndicatorComputeCommand.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Linq;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Indicators;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class IndicatorComputeCommand : Command
    {
        public IndicatorComputeCommand(IMonitoringManager monitoringManager)
            : base(Steps.DataAnalyzing, monitoringManager, 75)
        {
        }

        protected override void Process(ProcessingContext processingContext)
        {
            var rate = this.ComputeProgressionStep(processingContext);
            foreach (var sheet in processingContext.AvailableSheets)
            {

                foreach (var row in sheet.GetRows())
                {
                    foreach (var indicator in sheet.Indicators)
                    {
                        processingContext.ProgressRate += (int)rate;
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

        private decimal ComputeProgressionStep(ProcessingContext processingContext)
        {
            var rate = this.ProgressRate - processingContext.ProgressRate;
            var opertationCount = processingContext.AvailableSheets.Sum(x => x.Indicators.Count * x.RowCount);
            return opertationCount == 0 ? 0 : rate / opertationCount;
        }
    }
}
