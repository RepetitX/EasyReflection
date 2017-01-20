using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyReflection.Comparison
{
    public class ComparisonResult
    {
        public List<ComparisonResult> MemberDifferences { get; } = new List<ComparisonResult>();
        public string ValueA { get;  }
        public string ValueB { get;  }

        public ComparisonResult()
        {            
        }
        public ComparisonResult(string ValueA, string ValueB)
        {
            this.ValueA = ValueA;
            this.ValueB = ValueB;
        }

        public bool Different
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ValueA) && string.IsNullOrWhiteSpace(ValueB)
                    && !MemberDifferences.Any())
                {
                    return false;
                }
                return true;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            return result.ToString();
        }
    }
}
