using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyReflection.Cloning
{
    public abstract class EnumerableCloner : IObjectCloner
    {
        public T CloneObject<T>(T Object) where T : new()
        {
            throw new NotImplementedException();
        }

        public void CloneMember(PropertyInfo PropertyInfo, object Clone, object Source)
        {
            throw new NotImplementedException();
        }

        public bool IsClonable(PropertyInfo PropertyInfo)
        {
            throw new NotImplementedException();
        }

        public bool IsClonable(Type Type)
        {
            throw new NotImplementedException();
        }
    }
}
