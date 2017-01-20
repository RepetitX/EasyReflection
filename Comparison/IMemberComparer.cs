using System;

namespace EasyReflection.Comparison
{
    public interface IMemberComparer
    {
        MemberComparisonResult Compare(object MemberA, object MemberB);
        bool IsComparable(Type Type);
    }
}
