using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Indicators.Criterias;
using Alcuin.BDES.Indicators.Parser;

namespace Alcuin.BDES.Indicators
{
    internal class Indicator
    {
        private readonly IndicatorDefinition indicatorDefinition;

        public Indicator()
        {
            this.GroupedValues = new Dictionary<string, IndicatorValue>();
            this.Creterias = new List<ICriteria>();
        }

        public Indicator(List<ICriteria> criterias)
        {
            this.GroupedValues = new Dictionary<string, IndicatorValue>();
            this.Creterias = criterias;
        }

        public Indicator(IndicatorDefinition indicatorDefinition, List<ICriteria> criterias)
            : this(criterias)
        {
            this.indicatorDefinition = indicatorDefinition;
        }

        public Dictionary<string, IndicatorValue> GroupedValues { get; }

        public IEnumerable<Column> UsedColumns => this.Creterias.Select(x => x.Column).Union(new[] { this.ColumnToAgregate, this.GroupColumn });

        internal Column ColumnToAgregate { get; set; }

        internal Column GroupColumn { get; set; }

        internal AgregateFunction AgregateFunction => this.indicatorDefinition.AgregateFunction;

        public string SheetName => this.indicatorDefinition.SheetName;

        public string Domain => this.indicatorDefinition.Domain;

        public string SubDomain => this.indicatorDefinition.SubDomain;

        public string Name => this.indicatorDefinition.Name;

        public string Field => this.indicatorDefinition.Field;

        internal List<ICriteria> Creterias { get; set; }

        public IndicatorValue GetGroupValue(string key)
        {
            if (!this.GroupedValues.TryGetValue(key, out var indicatorValue))
            {
                indicatorValue = this.GroupedValues[key] = new IndicatorValue();
            }

            return indicatorValue;
        }

        public bool IsInclud(Aspose.Cells.Row row, int referenceYear)
        {
            var first = this.Creterias.First();
            var result = first.IsMatch(row, referenceYear);
            foreach (var item in this.Creterias.Skip(1))
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

        public override string ToString()
        {
            return this.Name;
        }
    }
}