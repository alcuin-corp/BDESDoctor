// <copyright file="StringExtensions.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using System;
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
            return obj.ToString().ToLowerInvariant();
        }

        public static bool EqualsTo(this string str, string value)
        {
            return str.Equals(value, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool In(this string str, params string[] values)
        {
            return values.Any(value => str.EqualsTo(value));
        }

        public static bool TryParseToDate(this string str, out DateTime date)
        {
            return DateTime.TryParseExact(str, ExpectedDateFormat, CultureInfo, DateTimeStyles.None, out date);
        }

        public static string ToFirstUpper(this string str)
        {
            if (str.IsEmpty())
            {
                var strBuilder = new StringBuilder(str);
                strBuilder[0] = char.ToUpper(strBuilder[0]);
                return strBuilder.ToString();
            }
            else
            {
                return str;
            }
        }
    }
}
