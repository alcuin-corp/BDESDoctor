// <copyright file="Token.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

namespace Alcuin.BDES.Indicators.Parser
{
    internal class Token
    {
        public Token(TokenType tokenType)
            : this(tokenType, string.Empty)
        {
        }

        public Token(TokenType tokenType, string value)
        {
            this.TokenType = tokenType;
            this.Value = value;
        }

        public TokenType TokenType { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.TokenType}-{this.Value}";
        }

        public Token Clone()
        {
            return new Token(this.TokenType, this.Value);
        }
    }
}
