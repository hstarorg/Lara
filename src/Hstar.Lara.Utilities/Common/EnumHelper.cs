using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Hstar.Lara.Utilities.Common
{
    /// <summary>
    /// The helper functions for enum.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Convert string to enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string str, bool ignoreCase = false) where T : struct
        {
            if (Enum.TryParse<T>(str, ignoreCase, out var enumValue))
            {
                return enumValue;
            }
            return default(T);
        }

        /// <summary>
        /// Convert string to enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value) where T : struct
        {
            var enumObj = Enum.ToObject(typeof(T), value);
            if (enumObj != null)
            {
                return (T)(enumObj);
            }
            return default(T);
        }

        /// <summary>
        /// Get enum name.
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumName(this Enum enumValue)
        {
            return Enum.GetName(enumValue.GetType(), enumValue);
        }

        /// <summary>
        /// Get enum entries(Name, Value, DisplayName)
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static IList<(string, int, string)> GetEnumEntries(this Enum enumValue)
        {
            var enumType = enumValue.GetType();

            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType);
            var descriptions = GetEnumValueDescription(enumType);

            var entryList = new List<(string, int, string)>();
            for (var i = 0; i < names.Length; i++)
            {
                entryList.Add((names[i], (int)values.GetValue(i), descriptions[i]));
            }
            return entryList;
        }

        /// <summary>
        /// Get enum entries(Name, Value, DisplayName)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<(string, int, string)> GetEnumEntries<T>() where T : struct
        {
            return GetEnumEntries(default(T) as Enum);
        }

        /// <summary>
        /// Get enum descriptions
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        private static string[] GetEnumValueDescription(Type enumType)
        {
            return enumType.GetFields(BindingFlags.Public | BindingFlags.Static).Select(value =>
            {
                var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(value, typeof(DescriptionAttribute));
                return attr?.Description ?? value.Name;
            }).ToArray<string>();
        }
    }
}
