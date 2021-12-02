using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _19_MonsterMessages_2
{
    public class Rule
    {
        public string String { get; set; }
        public string RegexPattern {get; set;}
        public int Id => int.Parse(String.Split(":").First());
        public Func<string,bool> MatchesRegex => (s) => Regex.IsMatch(s, $"^{RegexPattern}$");

        public string GetRegexPattern(Dictionary<int, Rule> rules, int depth)
        {
            depth++;
            if(RegexPattern != null) return RegexPattern;

            // case simple match
            var simpleMatch = Regex.Match(String, "\"(?<char>.+)\"");
            if(simpleMatch.Success)
            {
                RegexPattern = $"{simpleMatch.Groups["char"].Value}";
                return RegexPattern;
            }

            // case multiple cases with recursive
            if(String.Contains("|") && depth > 50)
            {
                var matches = Regex.Match(String, @": (?<firstParts>.+) \| (?<secondParts>.+)");
                var firstParts = matches
                    .Groups["firstParts"]
                    .Value
                    .Split(" ")
                    .Select(x => rules[int.Parse(x)].GetRegexPattern(rules, depth));
                RegexPattern = string.Join("", firstParts);
                // skip the second part
                return RegexPattern;
            }

            // case multiple cases
            if(String.Contains("|"))
            {
                var matches = Regex.Match(String, @": (?<firstParts>.+) \| (?<secondParts>.+)");
                var firstParts = matches
                    .Groups["firstParts"]
                    .Value
                    .Split(" ")
                    .Select(x => rules[int.Parse(x)].GetRegexPattern(rules, depth));
                var firstPart = string.Join("", firstParts);
                var secondParts = matches
                    .Groups["secondParts"]
                    .Value
                    .Split(" ")
                    .Select(x => rules[int.Parse(x)].GetRegexPattern(rules, depth));
                var secondPart = string.Join("", secondParts);
                RegexPattern = $"({firstPart}|{secondPart})";
                return RegexPattern;
            }

            // case one case
            var parts = String
                    .Split(":")
                    [1]
                    .Split(" ")
                    .Skip(1)
                    .Select(x => rules[int.Parse(x)].GetRegexPattern(rules, depth));
            RegexPattern = string.Join("", parts);
            return RegexPattern;
        } 
    }
}