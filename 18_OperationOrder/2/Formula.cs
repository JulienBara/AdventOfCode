using System.Linq;
using System.Text.RegularExpressions;

namespace _18_OperationOrder_2
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

            while(s.Contains("+"))
            {
                s = Regex.Replace(
                    s, 
                    @"(?<firstPart>\d+?) \+ (?<secondPart>\d+)",
                    match => (long.Parse(match.Groups["firstPart"].Value) + long.Parse(match.Groups["secondPart"].Value)).ToString()
                );
            }

            while(s.Contains("*"))
            {
                s = Regex.Replace(
                    s, 
                    @"(?<firstPart>\d+?) \* (?<secondPart>\d+)",
                    match => (long.Parse(match.Groups["firstPart"].Value) * long.Parse(match.Groups["secondPart"].Value)).ToString()
                );
            }
            
            return s;
        }
    }
}