namespace Alcuin.BDES.Indicators
{
    internal class MatchConditionDefinition
    {
        public string ColumnHeader { get; set; }

        public Operator Operator { get; set; }

        public object Values { get; set; }
    }
}
