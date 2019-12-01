using System.Collections.Generic;

namespace Alcuin.BDES.Indicators
{
    internal class MatchConditionDefinition
    {
        public string ColumnHeader { get; set; }

        public Operator Operator { get; set; }

        public List<object> Values { get; set; }

        public LogicalOperator LogicalOperatorToNextCondition { get; set; }

        public TransformationFunction TransformationFunction { get; set; }
    }
}