using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyReflection.Comparison
{
    public class SimpleTypeComparer : BaseComparer
    {
        public override ComparisonResult CompareObjects<T>(T ObjectA, T ObjectB)
        {
            if (ObjectA.Equals(ObjectB))
            {
                return new ComparisonResult();
            }
            return new ComparisonResult(ObjectA.ToString(), ObjectB.ToString());
        }

        public override bool IsComparable(MemberInfo MemberInfo)
        {
            var prop = MemberInfo as PropertyInfo;
            if (prop == null)
            {
                return false;
            }
            var eqType = typeof (IEquatable<>).MakeGenericType(prop.PropertyType);

            return prop.PropertyType.GetInterfaces().Contains(eqType);
        }
    }
}