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
            return Password[MinChar-1] == Char ^ Password[MaxChar-1] == Char;
        }
    }
}