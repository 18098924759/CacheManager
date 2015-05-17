using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace INGA.Framework.Helpers.Common
{
    public static class ClassHelper
    {
        public static T Cast<T>(Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            foreach (var memberInfo in members)
            {
                var propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                if (myobj.GetType().GetProperty(memberInfo.Name) != null)
                {
                    var value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);
                    if (propertyInfo.GetSetMethod() != null)
                        propertyInfo.SetValue(x, value, null);
                }
            }
            return (T)x;
        }
    }

}
