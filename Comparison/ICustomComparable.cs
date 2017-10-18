using System.Collections.Generic;

namespace EasyReflection.Comparison
{
    public interface ICustomComparable
    {
        IList<string> ComparableProperties { get; set; }
    }
}
