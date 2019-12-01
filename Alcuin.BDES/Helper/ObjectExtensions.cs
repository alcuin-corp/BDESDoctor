using System;

namespace Alcuin.BDES.Helper
{
    internal static class ObjectExtensions
    {
        public static bool IsGreaterThan(this object objToCompare, object referenceObject)
        {
            if (objToCompare.TryUnboxDecimal(out var valueToCompare) && referenceObject.TryUnboxDecimal(out var valueReference))
            {
                return valueToCompare > valueReference;
            }

            return string.Compare(objToCompare.ToString(), referenceObject.ToString()) == 1;
        }

        public static bool IsLessThan(this object objToCompare, object referenceObject)
        {
            if (objToCompare.TryUnboxDecimal(out var valueToCompare) && referenceObject.TryUnboxDecimal(out var valueReference))
            {
                return valueToCompare < valueReference;
            }

            return string.Compare(objToCompare.ToString(), referenceObject.ToString()) == -1;
        }

        private static bool TryUnboxDecimal(this object value, out decimal decimalValue)
        {
            if (value is decimal || value is int)
            {
                decimalValue = Convert.ToDecimal(value);
                return true;
            }

            return decimal.TryParse(value.ToString(), out decimalValue);
        }

        private static bool TryUnboxDate(this object value, out DateTime date)
        {
            if (value is DateTime)
            {
                date = (DateTime)value;
                return true;
            }

            return value.ToString().TryParseToDate(out date);
        }
    }
}