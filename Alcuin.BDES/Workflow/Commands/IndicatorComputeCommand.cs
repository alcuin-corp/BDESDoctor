﻿// <copyright file="IndicatorComputeCommand.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Linq;
using Alcuin.BDES.Indicators;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class IndicatorComputeCommand : Command
    {
        public IndicatorComputeCommand(IMonitoringManager monitoringManager)
            : base(Step.DataAnalyzing, monitoringManager, 95)
        {
        }

        protected override void Process(ProcessingContext processingContext, Request request)
        {
            var rate = this.ComputeProgressionStep(processingContext, request);
            foreach (var sheet in processingContext.AvailableSheets)
            {

                foreach (var row in sheet.GetRows())
                {
                    foreach (var indicator in sheet.Indicators)
                    {
                        request.ProgressRate += (int)rate;
                        var groupKey = indicator.GroupColumn.GetCleanCell(row);
                        var indicatorValue = indicator.GetGroupValue(groupKey);
                        if (indicator.IsInclud(row, request.ReferenceYear))
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

        private decimal ComputeProgressionStep(ProcessingContext processingContext, Request request)
        {
            var rate = this.ProgressRate - request.ProgressRate;
            var opertationCount = processingContext.AvailableSheets.Sum(x => x.Indicators.Count * x.RowCount);
            return opertationCount == 0 ? 0 : rate / opertationCount;
        }
    }
}
