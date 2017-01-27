using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyReflection.Comparison
{
    public class SimpleTypeComparer : BaseComparer
    {
        public override IComparisonResult CompareObjects<T>(T ObjectA, T ObjectB)
        {
            if (ObjectA == null && ObjectB == null)
            {
                return new SimpleComparisonResult();
            }
            if (ObjectA != null && ObjectA.Equals(ObjectB))
            {
                return new SimpleComparisonResult();
            }

            return new SimpleComparisonResult(ObjectA?.ToString(), ObjectB?.ToString());
        }

        public override bool IsComparable(MemberInfo MemberInfo)
        {
            var prop = MemberInfo as PropertyInfo;
            if (prop == null)
            {
                return false;
            }

            return prop.PropertyType.IsValueType ||
                   prop.PropertyType.Name == "String";
        }

        public override bool IsComparable(Type Type)
        {
            return Type.IsValueType ||
                   Type.Name == "String";
        }
    }
}