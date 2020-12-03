using System.Linq;

namespace _2_PasswordPhilosophy
{
    public class Policy
    {
        public int MinChar { get; set; }
        public int MaxChar { get; set; }
        public char Char { get; set; }
        public string Password { get; set; }

        public bool IsValid()
        {
            var count = Password
                .ToCharArray()
                .Where(x => x == Char)
                .Count();
            return MinChar <= count && count <= MaxChar;
        }
    }
}