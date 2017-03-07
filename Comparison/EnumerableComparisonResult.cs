using System.Collections.Generic;
using System.Linq;

namespace EasyReflection.Comparison
{
    public class EnumerableComparisonResult : IComparisonResult
    {
        public List<string> UniqueItemsA { get; } = new List<string>();
        public List<string> UniqueItemsB { get; } = new List<string>();
        public Dictionary<string, IComparisonResult> ItemDifferences { get; } =
            new Dictionary<string, IComparisonResult>();

        public Dictionary<string, IComparisonResult> UniqueItemsADifferences { get; } =
            new Dictionary<string, IComparisonResult>();
        public Dictionary<string, IComparisonResult> UniqueItemsBDifferences { get; } =
            new Dictionary<string, IComparisonResult>();

        public string MemberName { get; set; }

        public bool Different =>
            UniqueItemsA.Any() ||
            UniqueItemsB.Any() ||
            ItemDifferences.Any();
    }
}