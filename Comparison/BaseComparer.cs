using System.Reflection;

namespace EasyReflection.Comparison
{
    public abstract class BaseComparer : IObjectComparer
    {
        protected IComparerProvider comparerProvider;
        protected ComparisonMemberTypes memberTypes;

        public abstract ComparisonResult CompareObjects<T>(T ObjectA, T ObjectB);

        protected BaseComparer()
        {
            
        }

        protected BaseComparer(ComparisonMemberTypes MemberTypes, IComparerProvider ComparerProvider)
        {
            comparerProvider = ComparerProvider;
            memberTypes = MemberTypes;
        }

        public abstract bool IsComparable(MemberInfo MemberInfo);
    }
}