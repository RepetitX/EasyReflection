using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyReflection.Comparison
{
    public interface IObjectComparer
    {
        ComparisonResult CompareObjects<T>(T ObjectA, T ObjectB);
        bool IsComparable(MemberInfo MemberInfo);
    }
}