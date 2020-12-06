using System.Linq;

namespace _6_CustomCustoms_1
{
    public class Group
    {
        private string _toParse;

        public Group(string toParse)
        {
            _toParse = toParse;
        }

        public int NumberOfDifferentYes => _toParse
            .Where(character => character.ToString() != System.Environment.NewLine)
            .Distinct()
            .Count();
    }
}
