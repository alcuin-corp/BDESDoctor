using System;
using System.Collections.Generic;
using System.Linq;

namespace Alcuin.BDES.Indicators.Criterias
{
    internal class CriteriaDefinition
    {
        public CriteriaDefinition()
        {
            this.Values = new List<string>();
            this.ScalarFunction = ScalarFunction.None;
        }

        public string ColumnName { get; set; }

        public Operator Operator { get; set; }

        public List<string> Values { get; set; }

        public LogicalOperator LogicalOperatorToNextCondition { get; set; }

        public ScalarFunction ScalarFunction { get; set; }

        public CriteriaDefinition Clone()
        {
            var clone = (CriteriaDefinition)this.MemberwiseClone();
            return clone;
        }

        public override string ToString()
        {
            return $"{this.ColumnName} {this.Operator} {string.Join(", ", this.Values)}";
        }
    }
}
