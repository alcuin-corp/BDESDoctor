namespace Alcuin.BDES.Indicators.Parser
{
    internal class TokenMatch
    {
        public TokenType TokenType { get; set; }

        public string Value { get; set; }

        public int StartIndex { get; set; }

        public int EndIndex { get; set; }

        public int Precedence { get; set; }

        public override string ToString()
        {
            return $"{this.TokenType}-{this.Value}";
        }
    }
}