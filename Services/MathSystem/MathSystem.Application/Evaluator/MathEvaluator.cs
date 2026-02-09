using MathSystem.CORE.Interface;

namespace MathSystem.Application.Evaluator
{
    public class MathEvaluator : IMathEvaluator
    {
        public int Calc(string expression)
        {
            var tokens = Parse(expression);

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "*" || tokens[i] == "/")
                {
                    int result = tokens[i] == "*" ? Multiply(tokens[i - 1], tokens[i + 1])
                        : Divide(tokens[i - 1], tokens[i + 1]);

                    tokens[i - 1] = result.ToString();
                    tokens.RemoveAt(i);
                    tokens.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "+" || tokens[i] == "-")
                {
                    int result = tokens[i] == "+"
                        ? Add(tokens[i - 1], tokens[i + 1])
                        : Subtract(tokens[i - 1], tokens[i + 1]);

                    tokens[i - 1] = result.ToString();
                    tokens.RemoveAt(i);
                    tokens.RemoveAt(i);
                    i--;
                }
            }

            return Convert.ToInt32(tokens[0]);
        }
        public List<String> Parse(string expression)
        {
            var list = new List<String>();
            string number = "";

            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                }
                else
                {
                    list.Add(number);
                    list.Add(c.ToString());
                    number = "";
                }
            }

            list.Add(number);
            return list;
        }

        public int Add(string l, string r)
        {
            int result = Convert.ToInt32(l) + Convert.ToInt32(r);
            return result;
        }

        public int Subtract(string l, string r)
        {
            int result = Convert.ToInt32(l) - Convert.ToInt32(r);
            return result;
        }
        public int Multiply(string l, string r)
        {
            int result = Convert.ToInt32(l) * Convert.ToInt32(r);
            return result;
        }
        public int Divide(string l, string r)
        {
            int result = Convert.ToInt32(l) / Convert.ToInt32(r);
            return result;
        }
    }
}
