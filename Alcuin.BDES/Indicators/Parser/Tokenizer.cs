// <copyright file="Tokenizer.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

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
            this.AddTokenDefinition(TokenType.Agregate, "Count|∑|Somme|Moyenne|Moy|Avg", 1);
            this.AddTokenDefinition(TokenType.Where, "where|dont", 1);
            this.AddTokenDefinition(TokenType.GroupBy, "par|by", 1);
            this.AddTokenDefinition(TokenType.And, "et|and", 1);
            this.AddTokenDefinition(TokenType.Between, "entre|between", 1);
            this.AddTokenDefinition(TokenType.CloseParenthesis, "\\)", 1);
            this.AddTokenDefinition(TokenType.Comma, ",", 1);
            this.AddTokenDefinition(TokenType.Equals, "==|est", 1);
            this.AddTokenDefinition(TokenType.GreaterThan, ">>|supérieur", 1);
            this.AddTokenDefinition(TokenType.LessThan, "<<|inférieur", 1);
            this.AddTokenDefinition(TokenType.GreaterOrEquals, ">=", 1);
            this.AddTokenDefinition(TokenType.LessOrEquals, "<=", 1);
            this.AddTokenDefinition(TokenType.In, "in", 1);
            this.AddTokenDefinition(TokenType.NotIn, "pas dans|n'est pas dans|not in", 1);
            this.AddTokenDefinition(TokenType.NotEquals, "different|<>|!=", 1);
            this.AddTokenDefinition(TokenType.OpenParenthesis, "\\(", 1);
            this.AddTokenDefinition(TokenType.Or, "ou|or", 1);
            this.AddTokenDefinition(TokenType.DateTimeValue, @"'([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}'", 2);
            this.AddTokenDefinition(TokenType.StringValue, "'([^']*)'", 1);
            this.AddTokenDefinition(TokenType.Column, "(?:\\[)(?:[^\\]]*)(?:\\])", 3);
            this.AddTokenDefinition(TokenType.Number, "\\d+", 2);
            this.AddTokenDefinition(TokenType.YearOf, "année|YearOf", 1);
            this.AddTokenDefinition(TokenType.Age, "Age", 1);
            this.AddTokenDefinition(TokenType.Reference, "Reference|Référence", 1);
        }

        public IEnumerable<Token> Tokenize(string lqlText)
        {
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

                yield return new Token(bestMatch.TokenType, bestMatch.Value);

                lastMatch = bestMatch;
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
    }
}
