using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyReflection.Cloning
{
    public interface IObjectCloner
    {
        T CloneObject<T>(T Object) where T : new();
        void CloneMember(PropertyInfo PropertyInfo, object Clone, object Source);

        bool IsClonable(PropertyInfo PropertyInfo);
        bool IsClonable(Type Type);
    }
}
