using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace INGA.Framework.Helpers.Common
{
    public class EnumHelper
    {
        public static string GetEnumDescription<T>(T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public static string StringValueOf(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static object EnumValueOf(string value, Type enumType)
        {
            string[] names = Enum.GetNames(enumType);
            foreach (string name in names.Where(name => StringValueOf((Enum)Enum.Parse(enumType, name)).Equals(value)))
            {
                return Enum.Parse(enumType, name);
            }

            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }


    }
}
