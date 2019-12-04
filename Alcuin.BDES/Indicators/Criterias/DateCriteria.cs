using System;
using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Helper;
using Aspose.Cells;

namespace Alcuin.BDES.Indicators.Criterias
{
    internal class DateCriteria : Criteria
    {
        private readonly List<DateTime> Values;

        public DateCriteria(CriteriaDefinition criteriaDefinition)
            : base(criteriaDefinition)
        {
            this.Values = new List<DateTime>();
            foreach (var value in criteriaDefinition.Values)
            {
                    this.Values.Add(value.ParseDate());
            }
        }

        public override bool IsMatch(Row row, int referenceYear)
        {
            var cellValue = this.Column.GetCell(row).ParseDate();
            switch (this.Operator)
            {
                case Operator.Equals:
                    return cellValue.Equals(this.Values.First());
                case Operator.NotEquals:
                    return !cellValue.Equals(this.Values.First());
                case Operator.In:
                    return this.Values.Any(x => cellValue.Equals(x));
                case Operator.NotIn:
                    return this.Values.All(x => !cellValue.Equals(x));
                case Operator.GreaterThan:
                    return cellValue > this.Values.First();
                case Operator.GreaterOrEquals:
                    return cellValue >= this.Values.First();
                case Operator.LessThan:
                    return cellValue < this.Values.First();
                case Operator.LessOrEquals:
                    return cellValue <= this.Values.First();
                case Operator.Between:
                    return this.IsBetween(cellValue);
                case Operator.NotBetween:
                    return !this.IsBetween(cellValue);
                default:
                    throw new Exception($"Unknown operator : {this.Operator}");
            }
        }

        private bool IsBetween(DateTime cellValue)
        {
            return this.Values.Max() >= cellValue && this.Values.Min() <= cellValue;
        }
    }
}