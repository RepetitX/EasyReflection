using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyReflection.Cloning
{
    public abstract class ObjectCloner : IObjectCloner
    {
        protected IClonerProvider clonerProvider;
        protected List<string> ignoredProperties = new List<string>();

        protected ObjectCloner(IClonerProvider ClonerProvider)
        {
            clonerProvider = ClonerProvider;
        }

        public T CloneObject<T>(T Object) where T : new()
        {
            var members = typeof (T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            T result = new T();

            foreach (var member in members)
            {
                if (ignoredProperties.Contains(member.Name))
                {
                    continue;
                }
                var cloner = clonerProvider.GetCloner(member);
                if (cloner != null)
                {
                    cloner.CloneMember(member, result, Object);
                }
            }
            return result;
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

        protected object GetMemberValue(MemberInfo Member, object Object)
        {
            var prop = Member as PropertyInfo;
            if (prop == null)
            {
                return null;
            }
            return prop.GetValue(Object, null);
        }

        public abstract bool IsClonable(PropertyInfo PropertyInfo);
        public abstract bool IsClonable(Type Type);
    }
}
