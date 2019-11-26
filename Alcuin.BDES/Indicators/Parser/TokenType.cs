// <copyright file="TokenType.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

namespace Alcuin.BDES.Indicators.Parser
{
    internal enum TokenType
    {
        Agregate,
        GroupBy,
        Column,
        Where,
        And,
        Or,
        Between,
        Equals,
        NotEquals,
        GreaterThan,
        LessThan,
        GreaterOrEquals,
        LessOrEquals,
        In,
        NotIn,
        Differente,
        Comma,
        DateTimeValue,
        Number,
        CloseParenthesis,
        OpenParenthesis,
        StringValue,
        SequenceTerminator,
        YearOf,
        Age,
        Reference
    }
}
