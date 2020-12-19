using System.Linq;
using System.Text.RegularExpressions;

namespace _18_OperationOrder_1
{
    public class Formula
    {
        public string String { get; set; }

        public string EvaluateValue()
        {
            var s = new string(String);
            while(s.Contains("("))
            {
                s = Regex.Replace(
                    s, 
                    @"\([^\(.]*?\)", // smallest set of matching parenthesis
                    match => new Formula { String = match.Value.Substring(1, match.Value.Length - 2) }.EvaluateValue()
                );
            }
            
            var items = s.Split(" ");

            var accu = long.Parse(items.First());

            for (int i = 1; i < items.Length; i += 2)
            {
                switch (items[i])
                {
                    case "+":
                        accu += long.Parse(items[i+1]);
                        break;
                    case "-":
                        accu -= long.Parse(items[i+1]);
                        break;
                    case "*":
                        accu *= long.Parse(items[i+1]);
                        break;
                    case "/":
                        accu /= long.Parse(items[i+1]);
                        break;
                }
            }
            return accu.ToString();
        }
    }
}