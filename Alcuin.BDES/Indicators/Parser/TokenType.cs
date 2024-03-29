﻿namespace Alcuin.BDES.Indicators.Parser
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
        CloseParenthesis,
        OpenParenthesis,
        StringValue,
        SequenceTerminator,
        YearOf,
        Age,
        Reference,
        Seniority,
        Enum
    }
}