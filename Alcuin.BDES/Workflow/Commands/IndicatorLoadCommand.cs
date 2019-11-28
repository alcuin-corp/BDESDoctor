// <copyright file="IndicatorComputeCommand.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Indicators;
using Alcuin.BDES.Monitoring;

namespace Alcuin.BDES.Workflow.Commands
{
    internal class IndicatorLoadCommand : Command
    {
        private readonly IndicatorProvider indicatorProvider;

        public IndicatorLoadCommand(IMonitoringManager monitoringManager)
            : base(Step.IndicatorComputing, monitoringManager, 25)
        {
            this.indicatorProvider = new IndicatorProvider();
        }

        protected override void Process(ProcessingContext processingContext, Request request)
        {
            var allIndicators = this.indicatorProvider.GetAll()
                .ToList();

            foreach (var sheet in processingContext.AvailableSheets)
            {
                var availableIndicators = new List<Indicator>();
                var availableColumn = sheet.AvailableColumns.ToDictionary(x => x.Header.ToLowerInvariant());

                foreach (var indicator in allIndicators)
                {
                    if (this.TryMapIndicatorColumns(availableColumn, indicator, out var missingColumn))
                    {
                        sheet.Indicators.Add(indicator);
                        request.Indicators.Add(indicator);
                    }
                    else
                    {
                        this.PublishWarning($"L'indicateur '{indicator.Name}' ne sera pas calculé, il se base sur la colonne '{missingColumn}' qui est manquante dans l'onglet '{sheet.Name}'.");
                    }
                }
            }
        }

        private bool TryMapIndicatorColumns(Dictionary<string, Column> availableColumn, Indicator indicator, out string missingColumn)
        {
            if (!availableColumn.TryGetValue(indicator.ColumnToAgregateName, out var column))
            {
                missingColumn = indicator.ColumnToAgregateName;
                return false;
            }

            indicator.ColumnToAgregate = column;
            if (!availableColumn.TryGetValue(indicator.GroupColumnName, out column))
            {
                missingColumn = indicator.GroupColumnName;
                return false;
            }

            indicator.GroupColumn = column;
            foreach (var matchingCondition in indicator.MatchConditions)
            {
                if (!availableColumn.TryGetValue(matchingCondition.ColumnName, out column))
                {
                    missingColumn = matchingCondition.ColumnName;
                    return false;
                }

                matchingCondition.Column = column;
                this.CleanMatchingConditionValues(matchingCondition);
            }

            missingColumn = null;
            return true;
        }

        private void CleanMatchingConditionValues(MatchCondition mc)
        {
            if (!mc.UseFunction)
            {
                mc.Value = mc.Column.CleanValue(mc.Value.ToString());
            }//mc.Values = mc.Values?.Select(v => mc.Column.CleanValue(v)).ToList();
        }
    }
}