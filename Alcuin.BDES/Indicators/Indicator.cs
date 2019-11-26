// <copyright file="Indicator.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Domain;

namespace Alcuin.BDES.Indicators
{
    internal class Indicator
    {
        public readonly Dictionary<string, IndicatorValue> groupedValues;

        public Indicator()
        {
            this.groupedValues = new Dictionary<string, IndicatorValue>();
        }

        internal Column ColumnToAgregate { get; set; }

        internal string ColumnToAgregateName { get; set; }

        internal Column GroupColumn { get; set; }

        public string GroupColumnName { get; set; }

        internal AgregateFunction AgregateFunction { get; set; }

        public string Domain { get; set; }

        public string SubDomain { get; set; }

        public string Name { get; set; }

        public string Field { get; set; }

        public string Formula { get; set; }

        internal List<MatchCondition> MatchConditions { get; set; }

        public IndicatorValue GetGroupValue(string key)
        {
            if (!this.groupedValues.TryGetValue(key, out var indicatorValue))
            {
                indicatorValue = this.groupedValues[key] = new IndicatorValue();
            }

            return indicatorValue;
        }

        public bool IsInclud(Aspose.Cells.Row row, int referenceYear)
        {
            var first = this.MatchConditions.First();
            var result = first.IsMatch(row, referenceYear);
            foreach (var item in this.MatchConditions.Skip(1))
            {
                var nextResult = item.IsMatch(row, referenceYear);
                if (first.LogicalOperatorToNextCondition == LogicalOperator.And)
                {
                    result = result && nextResult;
                }
                else
                {
                    result = result || nextResult;
                }

                first = item;
            }

            return result;
        }
    }
}
