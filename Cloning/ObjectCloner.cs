using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyReflection.Cloning
{
    public abstract class ObjectCloner : IObjectCloner
    {
        protected IClonerProvider clonerProvider;
        protected List<string> ignoredProperties = new List<string>();

        protected Type objectType;

        protected ObjectCloner(IClonerProvider ClonerProvider, Type ObjectType)
        {
            clonerProvider = ClonerProvider;
            objectType = ObjectType;
        }

        protected ObjectCloner(IClonerProvider ClonerProvider)
        {
            clonerProvider = ClonerProvider;
            objectType = null;
        }

        public virtual T CloneObject<T>(T Object) where T : new()
        {
            var type = objectType ?? Object.GetType();

            var members = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            T result = (T) Initialize(type);

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

        protected virtual object Initialize(Type Type)
        {
            var ctor = Type.GetConstructor(new Type[] { });

            if (ctor == null)
            {
                throw new Exception($"Type {objectType} must have default constrctor");
            }

            object result = ctor.Invoke(null);

            return result;
        }

        public virtual void CloneMember(PropertyInfo PropertyInfo, object Clone, object Source)
        {
            if (!PropertyInfo.CanWrite)
            {
                return;
            }
            var sourceVal = PropertyInfo.GetValue(Source, null);
            var cloneVal = CloneObject(sourceVal);

            PropertyInfo.SetValue(Clone, cloneVal, null);
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
