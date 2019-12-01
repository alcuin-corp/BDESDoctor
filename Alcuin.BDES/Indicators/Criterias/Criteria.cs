using Alcuin.BDES.Domain;

namespace Alcuin.BDES.Indicators.Criterias
{
    internal abstract class Criteria : ICriteria
    {
        private readonly CriteriaDefinition criteriaDefinition;

        public Criteria(CriteriaDefinition criteriaDefinition)
        {
            this.criteriaDefinition = criteriaDefinition;
            this.ScalarFunction = criteriaDefinition.ScalarFunction;
            this.LogicalOperatorToNextCondition = criteriaDefinition.LogicalOperatorToNextCondition;
            this.Operator = criteriaDefinition.Operator;
        }

        public Column Column { get; set; }

        public Operator Operator { get; set; }

        public object Value { get; set; }

        public LogicalOperator LogicalOperatorToNextCondition { get; set; }

        public bool UseFunction => this.ScalarFunction != ScalarFunction.None;

        public ScalarFunction ScalarFunction { get; set; }

        public abstract bool IsMatch(Aspose.Cells.Row row, int referenceYear);
    }
}