namespace EasyReflection.Comparison
{
    public class MemberDifference
    {
        public string MemberName { get; }
        public string ValueA { get; }
        public string ValueB { get; }

        public MemberDifference(string MemberName, string ValueA, string ValueB)
        {
            this.MemberName = MemberName;
            this.ValueA = ValueA;
            this.ValueB = ValueB;
        }
    }
}
