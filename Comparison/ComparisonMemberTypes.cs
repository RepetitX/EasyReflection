using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyReflection.Comparison
{
    [Flags]
    public enum ComparisonMemberTypes
    {
        SimpleProperties = 1,
        ObjectProperties = 2,
        Enumerables = 4,
        All = 7
    }
}
