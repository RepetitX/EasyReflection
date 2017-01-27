using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyReflection.Comparison
{
    public interface IObjectComparer
    {
        IComparisonResult CompareObjects<T>(T ObjectA, T ObjectB);
        bool IsComparable(MemberInfo MemberInfo);
        bool IsComparable(Type Type);
    }
}