namespace EasyReflection.Comparison
{
    public class SimpleComparisonResult : IComparisonResult
    {
        public string MemberName { get; set; }
        public string ValueA { get; }
        public string ValueB { get; }

        public SimpleComparisonResult()
        {
            
        }

        public SimpleComparisonResult(string ValueA, string ValueB)
        {
            //this.PropertyName = PropertyName;
            this.ValueA = ValueA;
            this.ValueB = ValueB;
        }

        public bool Different => ValueA != ValueB;
    }
}
