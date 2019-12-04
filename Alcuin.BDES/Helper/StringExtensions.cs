using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Alcuin.BDES.Helper
{
    internal static class StringExtensions
    {
        private const string ExpectedDateFormat = "dd/MM/yyyy";
        private static readonly CultureInfo CultureInfo = new CultureInfo("fr-fr");

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNotEmpty(this string str)
        {
            return !str.IsEmpty();
        }

        public static string ToLowerString(this object obj)
        {
            return obj?.ToString().ToLowerInvariant();
        }

        public static bool EqualsTo(this string str, string value)
        {
            return str.Equals(value, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool In(this string str, params string[] values)
        {
            return values.Any(value => str.EqualsTo(value));
        }

        public static T ToEnum<T>(this string enumStr)
            where T : Enum
        {
            try
            {
                return (T)Enum.Parse(typeof(T), enumStr);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to cast value '{enumStr}' in enum '{typeof(T)}'", ex);
            }
        }

        public static string GetEnumDescription<T>(this string enumStr)
            where T : struct, Enum
        {
            if (enumStr.TryParseEnum(out T result))
            {
                return result.GetDescription();
            }

            return enumStr;
        }

        public static string GetEnumDescription(this string enumStr, Type enumType)
        {
            var memberInfo = enumType.GetMember(enumStr);
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attribs?.Count() > 0)
                {
                    return ((DescriptionAttribute)attribs.ElementAt(0)).Description;
                }
            }

            return enumStr;
        }

        public static bool TryParseEnum<T>(this string enumStr, out T result)
            where T : struct, Enum
        {
            return Enum.TryParse(enumStr, out result);
        }

        public static bool TryParseDate(this string str, out DateTime date)
        {
            return DateTime.TryParseExact(str, ExpectedDateFormat, CultureInfo, DateTimeStyles.None, out date);
        }

        public static DateTime ParseDate(this string str)
        {
            if (!str.TryParseDate(out var date))
            {
                throw new InvalidCastException($"{str} can not be parsed !");
            }

            return date;
        }

        public static string ToFirstUpper(this string str)
        {
            if (str.IsEmpty())
            {
                return str;
            }

            var strBuilder = new StringBuilder(str);
            strBuilder[0] = char.ToUpper(strBuilder[0]);

            return strBuilder.ToString();
        }
    }
}