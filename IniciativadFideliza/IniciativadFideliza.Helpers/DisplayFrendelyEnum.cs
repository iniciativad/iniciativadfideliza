using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace IniciativadFideliza.Helpers
{
    public class DisplayFrendelyEnum
    {
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
