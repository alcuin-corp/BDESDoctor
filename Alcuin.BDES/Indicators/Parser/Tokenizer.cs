using System.Collections.Generic;
using System.Linq;

namespace Alcuin.BDES.Indicators.Parser
{
    internal class Tokenizer
    {
        private readonly List<TokenDefinition> tokenDefinitions;

        public Tokenizer()
        {
            this.tokenDefinitions = new List<TokenDefinition>();
            this.AddTokenDefinition(TokenType.Agregate, "Count|Avg|Sum", 1);
            this.AddTokenDefinition(TokenType.Where, "where", 1);
            this.AddTokenDefinition(TokenType.GroupBy, "group by", 1);
            this.AddTokenDefinition(TokenType.And, "and", 1);
            this.AddTokenDefinition(TokenType.Between, "between", 1);
            this.AddTokenDefinition(TokenType.Comma, ",", 1);
            this.AddTokenDefinition(TokenType.Equals, "=", 2);
            this.AddTokenDefinition(TokenType.GreaterThan, ">", 2);
            this.AddTokenDefinition(TokenType.LessThan, "<", 2);
            this.AddTokenDefinition(TokenType.GreaterOrEquals, ">=", 1);
            this.AddTokenDefinition(TokenType.LessOrEquals, "<=", 1);
            this.AddTokenDefinition(TokenType.In, "In", 2);
            this.AddTokenDefinition(TokenType.NotIn, "Not In", 1);
            this.AddTokenDefinition(TokenType.NotEquals, "<>|!=", 1);
            this.AddTokenDefinition(TokenType.OpenParenthesis, "\\(", 1);
            this.AddTokenDefinition(TokenType.CloseParenthesis, "\\)", 1);
            this.AddTokenDefinition(TokenType.Or, "or", 1);
            this.AddTokenDefinition(TokenType.DateTimeValue, @"'([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}'", 2);
            this.AddTokenDefinition(TokenType.StringValue, "'([^']*)'", 2);
            this.AddTokenDefinition(TokenType.Column, "(?:\\[)(?:[^\\]]*)(?:\\])", 1);
            this.AddTokenDefinition(TokenType.YearOf, "YearOf", 1);
            this.AddTokenDefinition(TokenType.Age, "Age", 1);
            this.AddTokenDefinition(TokenType.Seniority, "Seniority", 1);
            this.AddTokenDefinition(TokenType.Reference, "Reference", 1);
        }

        public IEnumerable<Token> Tokenize(string lqlText)
        {
            var columns = this.FindColumns(lqlText)
                .Distinct()
                .ToDictionary(x => x.Replace("'", "%"));

            foreach (var col in columns)
            {
                lqlText = lqlText.Replace(col.Value, col.Key);
            }

            var tokenMatches = this.FindTokenMatches(lqlText);

            var groupedByIndex = tokenMatches.GroupBy(x => x.StartIndex)
                .OrderBy(x => x.Key)
                .ToList();

            TokenMatch lastMatch = null;
            for (int i = 0; i < groupedByIndex.Count; i++)
            {
                var bestMatch = groupedByIndex[i].OrderBy(x => x.Precedence).First();
                if (lastMatch != null && bestMatch.StartIndex < lastMatch.EndIndex)
                {
                    continue;
                }

                if (bestMatch.TokenType == TokenType.Column)
                {
                    bestMatch.Value = columns[bestMatch.Value];
                }

                lastMatch = bestMatch;

                yield return new Token(bestMatch.TokenType, bestMatch.Value);
            }

            yield return new Token(TokenType.SequenceTerminator);
        }

        private void AddTokenDefinition(TokenType tokenType, string regexPatten, int precedence)
        {
            this.tokenDefinitions.Add(new TokenDefinition(tokenType, regexPatten, precedence));
        }

        private List<TokenMatch> FindTokenMatches(string lqlText)
        {
            var tokenMatches = new List<TokenMatch>();

            foreach (var tokenDefinition in this.tokenDefinitions)
            {
                tokenMatches.AddRange(tokenDefinition.FindMatches(lqlText).ToList());
            }

            return tokenMatches;
        }

        private IEnumerable<string> FindColumns(string lqlText)
        {
            return this.tokenDefinitions.Where(x => x.ReturnsToken == TokenType.Column)
                .SelectMany(x => x.FindMatches(lqlText))
                .Select(x => x.Value);
        }
    }
}