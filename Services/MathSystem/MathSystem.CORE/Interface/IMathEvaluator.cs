namespace MathSystem.CORE.Interface
{
    public interface IMathEvaluator
    {
        int Calc(string expression);
        List<String> Parse(string expression);
        int Add(string l, string r);
        int Subtract(string l, string r);
        int Multiply(string l, string r);
        int Divide(string l, string r);
    }
}
