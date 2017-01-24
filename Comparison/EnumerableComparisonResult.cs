using System.Collections.Generic;
using System.Linq;

namespace EasyReflection.Comparison
{
    public class EnumerableComparisonResult : IComparisonResult
    {
        public List<string> UniqueItemsA { get; } = new List<string>();
        public List<string> UniqueItemsB { get; } = new List<string>();
        public List<IComparisonResult> ItemDifferences { get; } = new List<IComparisonResult>();

        public string MemberName { get; set; }

        public bool Different =>
            UniqueItemsA.Any() ||
            UniqueItemsB.Any() ||
            ItemDifferences.Any();
    }
}