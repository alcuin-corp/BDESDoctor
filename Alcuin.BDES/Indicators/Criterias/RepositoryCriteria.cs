using System;
using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Helper;
using Aspose.Cells;

namespace Alcuin.BDES.Indicators.Criterias
{

    internal class RepositoryCriteria<T> : Criteria
        where T : Enum
    {
        public List<T> Values;

        public RepositoryCriteria(CriteriaDefinition criteriaDefinition)
            : base(criteriaDefinition)
        {
            this.Values = new List<T>();
        }

        public override bool IsMatch(Row row, int referenceYear)
        {
            var cellValue = this.Column.GetCleanCell(row).ToEnum<T>();
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
