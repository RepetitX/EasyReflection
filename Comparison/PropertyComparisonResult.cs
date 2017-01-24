namespace EasyReflection.Comparison
{
    public class PropertyComparisonResult : IComparisonResult
    {
        public string PropertyName { get; set; }
        public string ValueA { get; }
        public string ValueB { get; }

        public PropertyComparisonResult()
        {
            
        }

        public PropertyComparisonResult(string ValueA, string ValueB)
        {
            //this.PropertyName = PropertyName;
            this.ValueA = ValueA;
            this.ValueB = ValueB;
        }

        public bool Different => ValueA != ValueB;
    }
}
