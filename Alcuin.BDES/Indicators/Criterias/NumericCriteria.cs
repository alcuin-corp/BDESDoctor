using System;
using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Helper;
using Aspose.Cells;

namespace Alcuin.BDES.Indicators.Criterias
{
    internal class NumericCriteria : Criteria
    {
        private readonly List<decimal> Values;

        public NumericCriteria(CriteriaDefinition criteriaDefinition)
            : base(criteriaDefinition)
        {
            this.Values = new List<decimal>();
            foreach (var value in criteriaDefinition.Values)
            {
                this.Values.Add(decimal.Parse(value));
            }
        }

        public override bool IsMatch(Row row, int referenceYear)
        {
            var str = this.Column.GetCell(row);
            var cellValue = this.UseFunction ? this.Transforme(str, referenceYear) : decimal.Parse(str);

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

        private decimal Transforme(string str, int referenceDate)
        {
            var date = str.ParseDate();
            if (this.ScalarFunction == ScalarFunction.YearOf)
            {
                return date.Year;
            }

            return referenceDate - date.Year;
        }

        private bool IsBetween(decimal cellValue)
        {
            return this.Values.Max() >= cellValue && this.Values.Min() <= cellValue;
        }
    }
}
