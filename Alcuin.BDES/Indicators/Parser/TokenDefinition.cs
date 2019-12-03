using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Alcuin.BDES.Indicators.Parser
{
    internal class TokenDefinition
    {
        private readonly int precedence;
        private readonly Regex regex;

        public TokenDefinition(TokenType returnsToken, string regexPattern, int precedence)
        {
            this.regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            this.ReturnsToken = returnsToken;
            this.precedence = precedence;
        }

        public TokenType ReturnsToken { get; }

        public IEnumerable<TokenMatch> FindMatches(string inputString)
        {
            var matches = this.regex.Matches(inputString);
            for (int i = 0; i < matches.Count; i++)
            {
                yield return new TokenMatch()
                {
                    StartIndex = matches[i].Index,
                    EndIndex = matches[i].Index + matches[i].Length,
                    TokenType = this.ReturnsToken,
                    Value = matches[i].Value,
                    Precedence = this.precedence
                };
            }
        }
    }
}