using System.Text.RegularExpressions;

namespace _4_PassportProcessing_2
{
    public class Passport
    {
        public string String { get; set; }

        public static Regex BirthYearRegex = new Regex(@"byr:(?<byr>.+)\b");
        public string BirthYear => BirthYearRegex.Match(String).Groups["byr"].Value;
        public static Regex IssueYearRegex = new Regex(@"iyr:(?<iyr>.+)\b");
        public string IssueYear => IssueYearRegex.Match(String).Groups["iyr"].Value;
        public static Regex ExpirationYearRegex = new Regex(@"eyr:(?<eyr>.+)\b");
        public string ExpirationYear => ExpirationYearRegex.Match(String).Groups["eyr"].Value;
        public static Regex HeightRegex = new Regex(@"hgt:(?<hgt>.+)\b");
        public string Height => HeightRegex.Match(String).Groups["hgt"].Value;
        public static Regex HairColorRegex = new Regex(@"hcl:(?<hcl>.+)\b");
        public string HairColor => HairColorRegex.Match(String).Groups["hcl"].Value;
        public static Regex EyeColorRegex = new Regex(@"ecl:(?<ecl>.+)\b");
        public string EyeColor => EyeColorRegex.Match(String).Groups["ecl"].Value;
        public static Regex PassportIdRegex = new Regex(@"pid:(?<pid>.+)\b");
        public string PassportId => PassportIdRegex.Match(String).Groups["pid"].Value;
        public static Regex CountryIdRegex = new Regex(@"cid:(?<cid>.+)\b");
        public string CountryId => CountryIdRegex.Match(String).Groups["cid"].Value;

        public bool IsValid => 
            ! string.IsNullOrEmpty(BirthYear) 
            && ! string.IsNullOrEmpty(IssueYear) 
            && ! string.IsNullOrEmpty(ExpirationYear) 
            && ! string.IsNullOrEmpty(Height) 
            && ! string.IsNullOrEmpty(HairColor)
            && ! string.IsNullOrEmpty(EyeColor)
            && ! string.IsNullOrEmpty(PassportId)
            // && ! string.IsNullOrEmpty(CountryId)
        ;

        

    }
}