using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QuadShapeFinder.Services.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription<T>(T enumOption)
        {
            string description = "";
            var type = typeof(T);
            var memberInfo = type.GetMember(enumOption.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Count() != 0)
            {
                description = ((DescriptionAttribute)attributes[0]).Description;
            }

            return description;
        }
    }
}
