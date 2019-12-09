using System;
using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Helper;
using Alcuin.BDES.Indicators.Criterias;

namespace Alcuin.BDES.Indicators.Parser
{
    internal class FormulaAnalyzer
    {
        private Stack<Token> tokenSequence;
        private Token head;
        private Token next;

        private CriteriaDefinition currentCriteriaDefinition;

        public FormulaAnalyzer(List<Token> tokens)
        {
            this.CriteriaDefinitions = new List<CriteriaDefinition>();
            this.Parse(tokens);
        }

        internal List<CriteriaDefinition> CriteriaDefinitions { get; }

        internal AgregateFunction AgregateFunction { get; private set; }

        internal string ColumnToAgregate { get; private set; }

        internal string GroupByColumn { get; private set; }

        public void Parse(List<Token> tokens)
        {
            this.LoadSequenceStack(tokens);
            this.head = this.tokenSequence.Pop();
            this.next = this.tokenSequence.Pop();
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

        private Token ReadToken(TokenType tokenType)
        {
            if (this.head.TokenType != tokenType)
            {
                throw new Exception($"Expected {tokenType.ToString().ToUpper()} but found: {this.head.Value}");
            }

            return this.head;
        }

        private void MoveNext()
        {
            this.head = this.next.Clone();

            if (this.tokenSequence.Any())
            {
                this.next = this.tokenSequence.Pop();
            }
            else
            {
                this.next = new Token(TokenType.SequenceTerminator, string.Empty);
            }
        }

        private void MoveNext(TokenType tokenType)
        {
            if (this.head.TokenType != tokenType)
            {
                throw new Exception($"Expected {tokenType.ToString().ToUpper()} but found: {this.head.Value}");
            }

            this.MoveNext();
        }

        private void Extract()
        {
            this.AgregateFunction = this.GetAgregateFunction();
            this.MoveNext();
            this.ColumnToAgregate = this.ReadColumnName();
            this.MoveNext();
            this.MoveNext(TokenType.GroupBy);
            this.GroupByColumn = this.ReadColumnName();
            this.MoveNext();
            this.MoveNext(TokenType.Where);
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
            return this.ReadToken(TokenType.StringValue).Value.Replace("'", string.Empty);
        }

        private AgregateFunction GetAgregateFunction()
        {
            if (this.head.TokenType != TokenType.Agregate)
            {
                throw new Exception($"Unknowen agregate function {this.head.Value}");
            }

            if (this.head.Value.EqualsTo("Avg"))
            {
                return AgregateFunction.Avg;
            }

            if (this.head.Value.EqualsTo("Sum"))
            {
                return AgregateFunction.Sum;
            }

            return AgregateFunction.Count;
        }

        private void MatchCondition(bool createNewMatch = true)
        {
            if (createNewMatch)
            {
                this.CreateNewMatchCondition();
            }

            switch (this.head.TokenType)
            {
                case TokenType.Column:

                    if (this.IsEqualityOperator(this.next))
                    {
                        this.EqualityMatchCondition();
                    }
                    else if (this.next.TokenType == TokenType.In)
                    {
                        this.InCondition();
                    }
                    else if (this.next.TokenType == TokenType.NotIn)
                    {
                        this.NotInCondition();
                    }
                    else if (this.next.TokenType == TokenType.Between)
                    {
                        this.BetweenCondition();
                    }
                    else
                    {
                        throw new Exception($"Value not expected {this.next.Value}");
                    }

                    this.MatchConditionNext();
                    break;
                case TokenType.YearOf:
                    this.HandleYearOfFunction();
                    break;
                case TokenType.Age:
                    this.AgeFunction();
                    break;

                case TokenType.Seniority:
                    this.SeniorityFunction();
                    break;
                default:
                    throw new Exception($"Value not expected {this.head.Value}");
            }
        }

        private void BetweenCondition()
        {
            this.currentCriteriaDefinition.ColumnName = this.ReadColumnName();
            this.MoveNext();
            this.currentCriteriaDefinition.Operator = Operator.Between;
            this.MoveNext(TokenType.Between);
            if (this.head.TokenType == TokenType.Reference)
            {
                this.currentCriteriaDefinition.Values.Add("reference");
            }
            else
            {
                this.currentCriteriaDefinition.Values.Add(this.ReadString());
            }

            this.MoveNext();
            this.MoveNext(TokenType.And);
            if (this.head.TokenType == TokenType.Reference)
            {
                this.currentCriteriaDefinition.Values.Add("reference");
            }
            else
            {
                this.currentCriteriaDefinition.Values.Add(this.ReadString());
            }

            this.MoveNext();
        }

        private void HandleYearOfFunction()
        {
            this.currentCriteriaDefinition.ScalarFunction = this.GetTransformFunction();
            this.MoveNext();
            this.MatchCondition(false);
        }

        private void SeniorityFunction()
        {
            this.currentCriteriaDefinition.ScalarFunction = this.GetTransformFunction();
            this.currentCriteriaDefinition.ColumnName = "Date d'entrée";
            this.MoveNext();
            this.currentCriteriaDefinition.Operator = this.GetOperator(this.head);
            this.MoveNext();
            this.currentCriteriaDefinition.Values.Add(this.ReadString());
            this.MoveNext();
            this.MatchConditionNext();
        }

        private void AgeFunction()
        {
            this.currentCriteriaDefinition.ScalarFunction = this.GetTransformFunction();
            this.currentCriteriaDefinition.ColumnName = "Date de naissance";
            this.MoveNext();
            this.currentCriteriaDefinition.Operator = this.GetOperator(this.head);
            this.MoveNext();
            this.currentCriteriaDefinition.Values.Add(this.ReadString());
            this.MoveNext();
            this.MatchConditionNext();
        }

        private ScalarFunction GetTransformFunction()
        {
            if (this.head.TokenType == TokenType.YearOf)
            {
                return ScalarFunction.YearOf;
            }

            return ScalarFunction.Age;
        }

        private void EqualityMatchCondition()
        {
            this.currentCriteriaDefinition.ColumnName = this.ReadColumnName();
            this.MoveNext();
            this.currentCriteriaDefinition.Operator = this.GetOperator(this.head);
            this.MoveNext();
            if (this.head.TokenType == TokenType.Reference)
            {
                this.currentCriteriaDefinition.Values.Add("reference");
            }
            else
            {
                this.currentCriteriaDefinition.Values.Add(this.ReadString());
            }

            this.MoveNext();
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

                case TokenType.In:
                    return Operator.In;

                case TokenType.NotIn:
                    return Operator.NotIn;

                default:
                    throw new Exception($"expected : {string.Join(", ", Enum.GetNames(typeof(Operator)))} but was {token.Value}");
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
            this.currentCriteriaDefinition.ColumnName = this.ReadColumnName();
            this.MoveNext();
            this.currentCriteriaDefinition.Operator = inOperator;

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
            this.MatchConditionNext();
        }

        private void StringLiteralList()
        {
            this.currentCriteriaDefinition.Values.Add(this.ReadString());
            this.DiscardToken(TokenType.StringValue);
            this.StringLiteralListNext();
        }

        private void StringLiteralListNext()
        {
            if (this.head.TokenType == TokenType.Comma)
            {
                this.DiscardToken(TokenType.Comma);
                this.currentCriteriaDefinition.Values.Add(this.ReadString());
                this.DiscardToken(TokenType.StringValue);
                this.StringLiteralListNext();
            }
        }

        private void MatchConditionNext()
        {
            if (this.head.TokenType == TokenType.SequenceTerminator)
            {
                return;
            }

            if (this.head.TokenType == TokenType.And)
            {
                this.AndMatchCondition();
            }
            else if (this.head.TokenType == TokenType.Or)
            {
                this.OrMatchCondition();
            }
            else if (this.head.TokenType == TokenType.Between)
            {
                this.DateCondition();
            }
            else
            {
                throw new Exception("Expected AND, OR or BETWEEN but found: " + this.head.Value);
            }
        }

        private void AndMatchCondition()
        {
            this.currentCriteriaDefinition.LogicalOperatorToNextCondition = LogicalOperator.And;
            this.DiscardToken(TokenType.And);
            this.MatchCondition();
        }

        private void OrMatchCondition()
        {
            this.currentCriteriaDefinition.LogicalOperatorToNextCondition = LogicalOperator.Or;
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
            if (head.TokenType == TokenType.SequenceTerminator)
            {
                // nothing
            }
            else
            {
                throw new Exception("Expected LIMIT or the end of the query but found: " + this.head.Value);
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
            this.currentCriteriaDefinition = new CriteriaDefinition();
            this.CriteriaDefinitions.Add(this.currentCriteriaDefinition);
        }
    }
}