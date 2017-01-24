namespace EasyReflection.Comparison
{
    public interface IComparisonResult
    {
        string MemberName { get; set; }
        bool Different { get; }
    }
}
