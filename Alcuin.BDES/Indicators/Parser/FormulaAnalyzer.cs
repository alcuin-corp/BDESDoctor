// <copyright file="FormulaAnalyzer.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Helper;

namespace Alcuin.BDES.Indicators.Parser
{
    internal class FormulaAnalyzer
    {
        private Stack<Token> tokenSequence;
        private Token lookaheadFirst;
        private Token lookaheadSecond;

        private MatchCondition currentMatchCondition;

        public FormulaAnalyzer(List<Token> tokens)
        {
            this.MatchConditions = new List<MatchCondition>();
            this.Parse(tokens);
        }

        internal List<MatchCondition> MatchConditions { get; }

        internal AgregateFunction AgregateFunction { get; private set; }

        internal string ColumnToAgregate { get; private set; }

        internal string GroupByColumn { get; private set; }

        public void Parse(List<Token> tokens)
        {
            this.LoadSequenceStack(tokens);
            this.PrepareLookaheads();
            this.Extract();
            this.DiscardToken(TokenType.SequenceTerminator);
        }

        private void LoadSequenceStack(List<Token> tokens)
        {
            this.tokenSequence = new Stack<Token>();
            int count = tokens.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                this.tokenSequence.Push(tokens[i]);
            }
        }

        private void PrepareLookaheads()
        {
            this.lookaheadFirst = this.tokenSequence.Pop();
            this.lookaheadSecond = this.tokenSequence.Pop();
        }

        private Token ReadToken(TokenType tokenType)
        {
            if (this.lookaheadFirst.TokenType != tokenType)
            {
                throw new Exception($"Expected {tokenType.ToString().ToUpper()} but found: {this.lookaheadFirst.Value}");
            }

            return this.lookaheadFirst;
        }

        private void DiscardToken()
        {
            this.lookaheadFirst = this.lookaheadSecond.Clone();

            if (this.tokenSequence.Any())
            {
                this.lookaheadSecond = this.tokenSequence.Pop();
            }
            else
            {
                this.lookaheadSecond = new Token(TokenType.SequenceTerminator, string.Empty);
            }
        }

        private void DiscardToken(TokenType tokenType)
        {
            if (this.lookaheadFirst.TokenType != tokenType)
            {
                throw new Exception($"Expected {tokenType.ToString().ToUpper()} but found: {this.lookaheadFirst.Value}");
            }

            this.DiscardToken();
        }

        private void Extract()
        {
            this.AgregateFunction = this.GetAgregateFunction();
            this.DiscardToken();
            this.ColumnToAgregate = this.ReadColumnName();
            this.DiscardToken();
            this.DiscardToken(TokenType.GroupBy);
            this.GroupByColumn = this.ReadColumnName();
            this.DiscardToken();
            this.DiscardToken(TokenType.Where);
            this.MatchCondition();
        }

        private string ReadColumnName()
        {
            return this.ReadToken(TokenType.Column).Value
                .Replace("[", string.Empty)
                .Replace("]", string.Empty)
                .ToLowerInvariant();
        }

        private string ReadString()
        {
            return this.ReadToken(TokenType.StringValue).Value
                .Replace("'", string.Empty);
        }

        private AgregateFunction GetAgregateFunction()
        {
            if (this.lookaheadFirst.TokenType == TokenType.Agregate)
            {
                if (this.lookaheadFirst.Value.In("count", "Sum", "∑"))
                {
                    return AgregateFunction.Count;
                }

                if (this.lookaheadFirst.Value.In("Avg", "Moy", "Moyenne"))
                {
                    return AgregateFunction.Avg;
                }
            }

            throw new Exception($"Unknowen agregate function {this.lookaheadFirst.Value}");
        }

        private void MatchCondition()
        {
            this.CreateNewMatchCondition();

            if (this.lookaheadFirst.TokenType == TokenType.Column)
            {
                if (this.IsEqualityOperator(this.lookaheadSecond))
                {
                    this.EqualityMatchCondition();
                }
                else if (this.lookaheadSecond.TokenType == TokenType.In)
                {
                    this.InCondition();
                }
                else if (this.lookaheadSecond.TokenType == TokenType.NotIn)
                {
                    this.NotInCondition();
                }
                else
                {
                    throw new Exception($"Value not expected {this.lookaheadSecond.Value}");
                }

                this.MatchConditionNext();
            }
            else if (this.lookaheadFirst.TokenType == TokenType.YearOf)
            {
                this.YearOfCondition();
            }
            else
            if (this.lookaheadFirst.TokenType == TokenType.Age)
            {
                this.AgeCondition();
            }
            else
            {
                throw new Exception($"Value not expected {this.lookaheadFirst.Value}");
            }
        }

        private void YearOfCondition()
        {
            this.currentMatchCondition.TransformationFunction = this.GetTransformFunction();
            this.currentMatchCondition.UseFunction = true;
            this.DiscardToken();
            this.currentMatchCondition.ColumnName = this.ReadColumnName();
            this.EqualityMatchCondition();
        }

        private void AgeCondition()
        {
            this.currentMatchCondition.TransformationFunction = this.GetTransformFunction();
            this.currentMatchCondition.UseFunction = true;
            this.currentMatchCondition.ColumnName = "date de naissance";
            this.DiscardToken();
            this.currentMatchCondition.Operator = this.GetOperator(this.lookaheadFirst);
            this.DiscardToken();
            this.currentMatchCondition.Value = this.ReadNumber();
            this.DiscardToken();
            this.MatchConditionNext();
        }

        private decimal ReadNumber()
        {
            return decimal.Parse(this.ReadToken(TokenType.Number).Value);
        }

        private TransformationFunction GetTransformFunction()
        {
            if (this.lookaheadFirst.TokenType == TokenType.YearOf)
            {
                return TransformationFunction.YearOf;
            }

            return TransformationFunction.Age;
        }

        private void EqualityMatchCondition()
        {
            this.currentMatchCondition.ColumnName = this.ReadColumnName();
            this.DiscardToken();
            this.currentMatchCondition.Operator = this.GetOperator(this.lookaheadFirst);
            this.DiscardToken();
            if (this.lookaheadFirst.TokenType == TokenType.Reference)
            {
                this.currentMatchCondition.Value = "reference";
            }
            else
            {
                this.currentMatchCondition.Value = this.ReadString();
            }

            this.DiscardToken();
        }

        private Operator GetOperator(Token token)
        {
            switch (token.TokenType)
            {
                case TokenType.Equals:
                    return Operator.Equals;

                case TokenType.NotEquals:
                    return Operator.NotEquals;

                case TokenType.GreaterThan:
                    return Operator.GreaterThan;

                case TokenType.GreaterOrEquals:
                    return Operator.GreaterOrEquals;

                case TokenType.LessOrEquals:
                    return Operator.LessOrEquals;

                case TokenType.LessThan:
                    return Operator.LessThan;

                default:
                    throw new Exception("Expected =, !=, LIKE, NOT LIKE, IN, NOT IN but found: " + token.Value);
            }
        }

        private void NotInCondition()
        {
            this.ParseInCondition(Operator.NotIn);
        }

        private void InCondition()
        {
            this.ParseInCondition(Operator.In);
        }

        private void ParseInCondition(Operator inOperator)
        {
            this.currentMatchCondition.Operator = inOperator;
            //this.currentMatchCondition.Values = new List<string>();
            this.currentMatchCondition.ColumnName = this.ReadColumnName();
            this.DiscardToken();

            if (inOperator == Operator.In)
            {
                this.DiscardToken(TokenType.In);
            }
            else if (inOperator == Operator.NotIn)
            {
                this.DiscardToken(TokenType.NotIn);
            }

            this.DiscardToken(TokenType.OpenParenthesis);
            this.StringLiteralList();
            this.DiscardToken(TokenType.CloseParenthesis);
        }

        private void StringLiteralList()
        {
            //this.currentMatchCondition.Values.Add(this.ReadString());
            this.DiscardToken(TokenType.StringValue);
            this.StringLiteralListNext();
        }

        private void StringLiteralListNext()
        {
            if (this.lookaheadFirst.TokenType == TokenType.Comma)
            {
                this.DiscardToken(TokenType.Comma);
                // this.currentMatchCondition.Values.Add(this.ReadString());
                this.DiscardToken(TokenType.StringValue);
                this.StringLiteralListNext();
            }
        }

        private void MatchConditionNext()
        {
            if (this.lookaheadFirst.TokenType == TokenType.SequenceTerminator)
            {
                return;
            }

            if (this.lookaheadFirst.TokenType == TokenType.And)
            {
                this.AndMatchCondition();
            }
            else if (this.lookaheadFirst.TokenType == TokenType.Or)
            {
                this.OrMatchCondition();
            }
            else if (this.lookaheadFirst.TokenType == TokenType.Between)
            {
                this.DateCondition();
            }
            else
            {
                throw new Exception("Expected AND, OR or BETWEEN but found: " + this.lookaheadFirst.Value);
            }
        }

        private void AndMatchCondition()
        {
            this.currentMatchCondition.LogicalOperatorToNextCondition = LogicalOperator.And;
            this.DiscardToken(TokenType.And);
            this.MatchCondition();
        }

        private void OrMatchCondition()
        {
            this.currentMatchCondition.LogicalOperatorToNextCondition = LogicalOperator.Or;
            this.DiscardToken(TokenType.Or);
            this.MatchCondition();
        }

        private void DateCondition()
        {
            this.DiscardToken(TokenType.Between);

            //_queryModel.DateRange = new DateRange();
            //_queryModel.DateRange.From = DateTime.ParseExact(ReadToken(TokenType.DateTimeValue).Value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DiscardToken(TokenType.DateTimeValue);
            DiscardToken(TokenType.And);
            //_queryModel.DateRange.To = DateTime.ParseExact(ReadToken(TokenType.DateTimeValue).Value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            this.DiscardToken(TokenType.DateTimeValue);
            this.DateConditionNext();
        }

        private void DateConditionNext()
        {
            if (lookaheadFirst.TokenType == TokenType.SequenceTerminator)
            {
                // nothing
            }
            else
            {
                throw new Exception("Expected LIMIT or the end of the query but found: " + this.lookaheadFirst.Value);
            }

        }

        private bool IsEqualityOperator(Token token)
        {
            return token.TokenType == TokenType.Equals
                   || token.TokenType == TokenType.NotEquals
                   || token.TokenType == TokenType.GreaterThan
                   || token.TokenType == TokenType.GreaterOrEquals
                   || token.TokenType == TokenType.LessThan
                   || token.TokenType == TokenType.LessOrEquals;
        }

        private void CreateNewMatchCondition()
        {
            this.currentMatchCondition = new MatchCondition();
            this.MatchConditions.Add(this.currentMatchCondition);
        }
    }
}
