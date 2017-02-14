using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyReflection.Cloning
{
    public class SimpleTypeCloner : IObjectCloner
    {
        public T CloneObject<T>(T Object) where T : new()
        {
            return Object;
        }

        public void CloneMember(PropertyInfo PropertyInfo, object Clone, object Source)
        {
            if (!PropertyInfo.CanWrite)
            {
                return;
            }
            var propVal = PropertyInfo.GetValue(Source, null);
            PropertyInfo.SetValue(Clone, propVal, null);
        }

        public bool IsClonable(PropertyInfo PropertyInfo)
        {
            return IsClonable(PropertyInfo.PropertyType);
        }

        public bool IsClonable(Type Type)
        {
            return Type.IsValueType || Type.Name == "String";
        }
    }
}
