using System;
using System.Collections.Generic;
using System.Linq;
using Alcuin.BDES.Domain;
using Alcuin.BDES.Helper;

namespace Alcuin.BDES.Indicators
{
    internal class MatchCondition
    {
        public string ColumnName { get; set; }

        public Column Column { get; set; }

        public Operator Operator { get; set; }

        public object Value { get; set; }

        public List<object> Values { get; set; }

        public LogicalOperator LogicalOperatorToNextCondition { get; set; }

        public bool UseFunction { get; set; }

        public TransformationFunction TransformationFunction { get; set; }

        public bool IsMatch(Aspose.Cells.Row row, int referenceYear)
        {
            if (this.Value.Equals("reference"))
            {
                this.Value = referenceYear;
            }

            object value = this.Column.GetCleanCell(row);

            if (this.UseFunction)
            {
                value = this.TransformeValue(value.ToString(), referenceYear);
            }

            return this.CheckValue(value);
        }

        public override string ToString()
        {
            var part1 = this.UseFunction ? $"{this.TransformationFunction}({this.ColumnName})" : this.ColumnName;
            return $"{part1} {this.Operator} {this.Value}";
        }

        private static int GetYear(string value)
        {
            if (value.TryParseToDate(out var date))
            {
                return date.Year;
            }

            throw new Exception($"Impossible de convertir la valeur {value} en date");
        }

        private bool CheckValue(object value)
        {
            switch (this.Operator)
            {
                case Operator.Equals:
                    return value.Equals(this.Value);
                case Operator.NotEquals:
                    return !value.Equals(this.Value);
                case Operator.In:
                    return this.Values.Any(x => value.Equals(x));
                case Operator.NotIn:
                    return this.Values.All(x => !value.Equals(x));
                case Operator.GreaterThan:
                    return value.IsGreaterThan(this.Value);
                case Operator.GreaterOrEquals:
                    return value.IsGreaterThan(this.Value) || value.Equals(this.Value);
                case Operator.LessThan:
                    return value.IsLessThan(this.Value);
                case Operator.LessOrEquals:
                    return value.IsLessThan(this.Value) || value.Equals(this.Value);
                case Operator.Between:
                    return this.IsBetween(value);
                default:
                    throw new Exception("Unknown comparaison Operator");
            }
        }

        private bool IsBetween(object value)
        {
            var min = this.Values.Min();
            var isGreterOrEqaulsMin = value.IsGreaterThan(min) || value.Equals(min);
            var max = this.Values.Max();
            var isLessOrEqualsMax = value.IsLessThan(max) || value.Equals(max);

            return isGreterOrEqaulsMin && isLessOrEqualsMax;
        }

        private object TransformeValue(string value, int referenceYear)
        {
            switch (this.TransformationFunction)
            {
                case TransformationFunction.Age:
                    return this.ComputeAge(value, referenceYear);
                case TransformationFunction.YearOf:
                    return GetYear(value);
                default:
                    break;
            }

            return value;
        }

        private decimal ComputeAge(string value, int referenceYear)
        {
            var yearOfBirth = GetYear(value);
            decimal age = referenceYear - yearOfBirth;
            return age;
        }
    }
}