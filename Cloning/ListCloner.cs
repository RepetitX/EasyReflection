﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EasyReflection.Cloning
{
    public abstract class ListCloner : IObjectCloner
    {
        protected bool copyItems;
        protected IClonerProvider clonerProvider;

        protected ListCloner(bool CopyItems, IClonerProvider ClonerProvider)
        {
            copyItems = CopyItems;
            clonerProvider = ClonerProvider;
        }

        public T CloneObject<T>(T Object) where T : new()
        {
            var list = Object as IList;
            if (list == null)
            {
                return default(T);
            }
            var result = new T();

            foreach (var obj in list)
            {
                ((IList) result).Add(CloneSourceItem(obj));
            }
            return result;
        }

        public void CloneMember(PropertyInfo PropertyInfo, object Clone, object Source)
        {
            var cloneProperty = PropertyInfo.GetValue(Clone, null);
            var sourceProperty = PropertyInfo.GetValue(Source, null) as IList;

            if (sourceProperty == null)
            {
                return;                
            }
            if (cloneProperty == null)
            {
                //initialize
                InitializeProperty(PropertyInfo, Clone);
                cloneProperty = PropertyInfo.GetValue(Clone, null);
            }
            var addMethod =
                PropertyInfo.PropertyType.GetInterfaces()
                    .FirstOrDefault(i => i.Name == "ICollection`1")
                    ?.GetMethod("Add");

            if (addMethod == null)
            {
                return;
            }
            foreach (var item in sourceProperty)
            {
                var clonedItem = CloneSourceItem(item);
                addMethod.Invoke(cloneProperty, new[] {clonedItem});
            }
        }

        protected virtual void InitializeProperty(PropertyInfo PropertyInfo, object Object)
        {
            Type itemType;
            if (PropertyInfo.PropertyType.Name == "IList`1")
            {
                itemType = PropertyInfo.PropertyType.GenericTypeArguments[0];
            }
            else
            {
                itemType =
                    PropertyInfo.PropertyType.GetInterfaces()
                        .FirstOrDefault(i => i.Name == "IList`1")
                        .GenericTypeArguments[0];
            }
            var constructor = typeof (List<>).MakeGenericType(itemType).GetConstructor(new Type[] {});

            if (constructor == null || !PropertyInfo.CanWrite)
            {
                return;
            }
            var cloneProperty = constructor.Invoke(null);
            PropertyInfo.SetValue(Object, cloneProperty, null);
        }

        protected object CloneSourceItem(object SourceItem)
        {
            if (copyItems)
            {
                return SourceItem;
            }
            var cloner = clonerProvider.GetCloner(SourceItem.GetType());
            if (cloner != null)
            {
                return cloner.CloneObject(SourceItem);
            }
            else
            {
                throw new Exception($"Unable to find cloner for {SourceItem.GetType()}");
            }
        }

        public abstract bool IsClonable(PropertyInfo PropertyInfo);
        public abstract bool IsClonable(Type Type);
    }
}