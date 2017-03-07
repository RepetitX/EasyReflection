using System;
using System.Reflection;

namespace EasyReflection.Comparison
{
    public class StringComparer : BaseComparer
    {
        public override IComparisonResult CompareObjects<T>(T ObjectA, T ObjectB)
        {
            var stringA = ObjectA as string;
            var stringB = ObjectB as string;
            if (string.IsNullOrWhiteSpace(stringA) &&
                string.IsNullOrWhiteSpace(stringB))
            {
                return new SimpleComparisonResult();
            }
            if (stringA != null && ObjectA.Equals(stringB))
            {
                return new SimpleComparisonResult();
            }

            return new SimpleComparisonResult(stringA, stringB);
        }

        public override bool IsComparable(MemberInfo MemberInfo)
        {
            var prop = MemberInfo as PropertyInfo;
            if (prop == null)
            {
                return false;
            }

            return IsComparable(prop.PropertyType);
        }

        public override bool IsComparable(Type Type)
        {
            return Type.Name == "String";
        }
    }
}