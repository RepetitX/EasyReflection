using System.Collections.Generic;
using System.Reflection;

namespace EasyReflection.Comparison
{
    public class ListComparerProvider : IComparerProvider
    {
        private readonly List<IObjectComparer> comparers = new List<IObjectComparer>();

        public ListComparerProvider AddComparer(IObjectComparer Comparer)
        {
            comparers.Add(Comparer);
            return this;
        }

        public IObjectComparer GetComparer(MemberInfo MemberInfo)
        {
            foreach (var cmp in comparers)
            {
                if (cmp.IsComparable(MemberInfo))
                {
                    return cmp;
                }
            }
            return null;
        }
    }
}
