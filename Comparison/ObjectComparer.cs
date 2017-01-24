using System.Collections.Generic;
using System.Reflection;

namespace EasyReflection.Comparison
{
    public class ObjectComparer : BaseComparer
    {        
        private List<string> ignoredProperties = new List<string>();

        public ObjectComparer(ComparisonMemberTypes MemberTypes, IComparerProvider ComparerProvider)
            : base(MemberTypes, ComparerProvider)
        {            
        }

        public override bool IsComparable(MemberInfo MemberInfo)
        {
            return true;
        }

        public override IComparisonResult CompareObjects<T>(T ObjectA, T ObjectB)
        {
            var members = typeof (T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            ObjectComparisonResult result = new ObjectComparisonResult();

            foreach (var member in members)
            {
                var comparer = comparerProvider.GetComparer(member);
                if (comparer != null)
                {
                    object valA = GetMemberValue(member, ObjectA);
                    object valB = GetMemberValue(member, ObjectB);

                    var memberDifference = comparer.CompareObjects(valA, valB);
                    if (memberDifference.Different)
                    {
                        //memberDifference.MemberName = member.Name;
                        result.MemberDifferences.Add(memberDifference);
                    }
                }
            }
            return result;
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
    }
}
