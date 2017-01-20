using System.Reflection;

namespace EasyReflection.Comparison
{
    public interface IComparerProvider
    {
        IObjectComparer GetComparer(MemberInfo MemberInfo);
    }
}
