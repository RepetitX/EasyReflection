using System.Collections.Generic;
using System.Linq;

namespace EasyReflection.Comparison
{
    public class ObjectComparisonResult : IComparisonResult
    {
        public List<IComparisonResult> MemberDifferences { get; } = new List<IComparisonResult>();
        public string MemberName { get; set; }
        public bool Different => MemberDifferences.Any();
    }
}