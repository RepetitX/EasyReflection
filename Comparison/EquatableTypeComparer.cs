using System;
using System.Reflection;

namespace EasyReflection.Comparison
{
    public class EquatableTypeComparer : BaseComparer
    {
        public override IComparisonResult CompareObjects<T>(T ObjectA, T ObjectB)
        {
            if (ObjectA == null && ObjectB == null)
            {
                return new EquatableComparisonResult();
            }
            if (ObjectA != null && ObjectA.Equals(ObjectB))
            {
                return new EquatableComparisonResult();
            }

            return new EquatableComparisonResult(ObjectA, ObjectB);
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
            return Type.IsValueType ||
                   Type.Name == "String";
        }
    }
}