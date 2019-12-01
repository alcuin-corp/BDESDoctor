using System;
using System.ComponentModel;
using System.Linq;

namespace Alcuin.BDES.Helper
{
    internal static class EnumExtensions
    {
        public static string GetDescription<T>(this T enumValue)
            where T : Enum
        {
            var genericEnumType = enumValue.GetType();
            var memberInfo = genericEnumType.GetMember(enumValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attribs?.Count() > 0)
                {
                    return ((DescriptionAttribute)attribs.ElementAt(0)).Description;
                }
            }

            return enumValue.ToString();
        }
    }
}
