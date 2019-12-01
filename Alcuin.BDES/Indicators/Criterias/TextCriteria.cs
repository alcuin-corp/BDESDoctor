using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Cells;

namespace Alcuin.BDES.Indicators.Criterias
{
    internal class TextCriteria : Criteria
    {
        private readonly List<string> Values;

        public TextCriteria(CriteriaDefinition criteriaDefinition)
            : base(criteriaDefinition)
        {
            this.Values = new List<string>(criteriaDefinition.Values);
        }

        public override bool IsMatch(Row row, int referenceYear)
        {
            var cellValue = this.Column.GetCell(row);
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
                    return cellValue.CompareTo(this.Values.First()) > 1;
                case Operator.GreaterOrEquals:
                    return cellValue.CompareTo(this.Values.First()) >= 0;
                case Operator.LessThan:
                    return cellValue.CompareTo(this.Values.First()) < 0;
                case Operator.LessOrEquals:
                    return cellValue.CompareTo(this.Values.First()) <= 0;
                case Operator.Between:
                    return this.IsBetween(cellValue);
                case Operator.NotBetween:
                    return !this.IsBetween(cellValue);
                default:
                    throw new Exception($"Unknown operator : {this.Operator}");
            }
        }

        private bool IsBetween(string cellValue)
        {
            return this.Values.Max().CompareTo(cellValue) >= 1 && this.Values.Min().CompareTo(cellValue) <= 1;
        }
    }
}