using System;
using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Helper;
using Aspose.Cells;

namespace Alcuin.BDES.Indicators.Criterias
{
    internal class NumericCriteria : Criteria
    {
        private readonly List<decimal?> values;

        public NumericCriteria(CriteriaDefinition criteriaDefinition)
            : base(criteriaDefinition)
        {
            this.values = new List<decimal?>();

            if (criteriaDefinition.Values.Any(x => x.EqualsTo("reference")))
            {
                this.UseRequestParameter = true;
            }

            if (criteriaDefinition.Values.Any(x => x.EqualsTo("Null")))
            {
                this.values.Add(null);
            }

            foreach (var value in criteriaDefinition.Values.Where(x => !x.In("reference", "Null")))
            {
                this.values.Add(decimal.Parse(value));
            }
        }

        public override bool IsMatch(Row row, int referenceYear)
        {
            if (this.UseRequestParameter && !this.values.Contains(referenceYear))
            {
                this.values.Add(referenceYear);
            }

            var cellValue = this.GetCellValue(row, referenceYear);

            switch (this.Operator)
            {
                case Operator.Equals:
                    return cellValue.Equals(this.values.First());
                case Operator.NotEquals:
                    return !cellValue.Equals(this.values.First());
                case Operator.In:
                    return this.values.Any(x => cellValue.Equals(x));
                case Operator.NotIn:
                    return this.values.All(x => !cellValue.Equals(x));
                case Operator.GreaterThan:
                    return cellValue > this.values.Max();
                case Operator.GreaterOrEquals:
                    return cellValue >= this.values.Max();
                case Operator.LessThan:
                    return cellValue < this.values.Min();
                case Operator.LessOrEquals:
                    return cellValue <= this.values.Min();
                case Operator.Between:
                    return cellValue.HasValue && this.IsBetween(cellValue.Value);
                case Operator.NotBetween:
                    return cellValue.HasValue && !this.IsBetween(cellValue.Value);
                default:
                    throw new Exception($"Unknown operator : {this.Operator}");
            }
        }

        private decimal? GetCellValue(Row row, int referenceYear)
        {
            var str = this.Column.GetCell(row);
            if (str.IsEmpty() && this.Column.AllowDuplicateValues)
            {
                return null;
            }

            var cellValue = this.UseFunction ? this.Transforme(str, referenceYear) : decimal.Parse(str);
            return cellValue;
        }

        private decimal Transforme(string str, int referenceDate)
        {
            var date = str.ParseDate();
            if (str.IsEmpty() && this.ScalarFunction == ScalarFunction.YearOfOrDefault)
            {
                return referenceDate;
            }

            if (this.ScalarFunction == ScalarFunction.YearOf)
            {
                return date.Year;
            }

            return (referenceDate + 1) - date.Year;
        }

        private bool IsBetween(decimal cellValue)
        {
            return this.values.Max() >= cellValue && this.values.Min() <= cellValue;
        }
    }
}