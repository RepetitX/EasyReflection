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
                return new PropertyComparisonResult();
            }
            if (ObjectA != null && ObjectA.Equals(ObjectB))
            {
                return new PropertyComparisonResult();
            }

            return new PropertyComparisonResult(ObjectA?.ToString(), ObjectB?.ToString());
        }

        public override bool IsComparable(MemberInfo MemberInfo)
        {
            var prop = MemberInfo as PropertyInfo;
            if (prop == null)
            {
                return false;
            }

            return prop.PropertyType.BaseType?.Name == "ValueType" ||
                   prop.PropertyType.BaseType?.Name == "Enum" ||
                   prop.PropertyType.Name == "String";
            var eqType = typeof (IEquatable<>).MakeGenericType(prop.PropertyType);

            return prop.PropertyType.GetInterfaces().Contains(eqType);
        }
    }
}