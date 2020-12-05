using System;
using System.Text.RegularExpressions;

namespace _4_PassportProcessing_2
{
    public class Passport
    {
        public string String { get; set; }

        public static Regex BirthYearRegex = new Regex(@"byr:(?<byr>.+?)\b");
        public string BirthYear => BirthYearRegex.Match(String).Groups["byr"].Value;
        public bool IsBirthYearValid => 
            ! string.IsNullOrEmpty(BirthYear)
            && int.TryParse(BirthYear, out _) 
            && 1920 <= int.Parse(BirthYear) 
            && int.Parse(BirthYear) <= 2002
            ;

        public static Regex IssueYearRegex = new Regex(@"iyr:(?<iyr>.+?)\b");
        public string IssueYear => IssueYearRegex.Match(String).Groups["iyr"].Value;
        public bool IsIssueYearValid => 
            ! string.IsNullOrEmpty(IssueYear)
            && int.TryParse(IssueYear, out _) 
            && 2010 <= int.Parse(IssueYear) 
            && int.Parse(IssueYear) <= 2020 
            ;

        public static Regex ExpirationYearRegex = new Regex(@"eyr:(?<eyr>.+?)\b");
        public string ExpirationYear => ExpirationYearRegex.Match(String).Groups["eyr"].Value;
        public bool IsExpirationYearValid => 
            ! string.IsNullOrEmpty(ExpirationYear)
            && int.TryParse(ExpirationYear, out _) 
            && 2020 <= int.Parse(ExpirationYear) 
            && int.Parse(ExpirationYear) <= 2030 
            ;
        
        public static Regex HeightRegex = new Regex(@"hgt:(?<hgt>.+?)\b");
        public string Height => HeightRegex.Match(String).Groups["hgt"].Value;
        public bool IsHeightValid => 
            ! string.IsNullOrEmpty(Height)
            && (
                (Height.EndsWith("in") && 59 <= int.Parse(Height.Substring(0, Height.Length - "in".Length)) && int.Parse(Height.Substring(0, Height.Length - "in".Length)) <= 76)
                ||  (Height.EndsWith("cm") && 150 <= int.Parse(Height.Substring(0, Height.Length - "cm".Length)) && int.Parse(Height.Substring(0, Height.Length - "cm".Length)) <= 193)
            )
            ;        

        public static Regex HairColorRegex = new Regex(@"hcl:(?<hcl>#.+?)\b");
        public string HairColor => HairColorRegex.Match(String).Groups["hcl"].Value;
        public bool IsHairColorValid => 
            ! string.IsNullOrEmpty(HairColor)
            && Regex.IsMatch(HairColor, @"#[0-9a-f]{6}")
            ;

        public static Regex EyeColorRegex = new Regex(@"ecl:(?<ecl>.+?)\b");
        public string EyeColor => EyeColorRegex.Match(String).Groups["ecl"].Value;
        public bool IsEyeColorValid => 
            ! string.IsNullOrEmpty(EyeColor)
            && Regex.IsMatch(EyeColor, @"amb|blu|brn|gry|grn|hzl|oth")
            ;

        public static Regex PassportIdRegex = new Regex(@"pid:(?<pid>.+?)\b");
        public string PassportId => PassportIdRegex.Match(String).Groups["pid"].Value;
        public bool IsPassportIdValid => 
            ! string.IsNullOrEmpty(PassportId)
            && Regex.IsMatch(PassportId, @"\b\d{9}\b")
            ;

        // public static Regex CountryIdRegex = new Regex(@"cid:(?<cid>.+?)\b");
        // public string CountryId => CountryIdRegex.Match(String).Groups["cid"].Value;
        // public bool IsCountryIdValid => ! string.IsNullOrEmpty(CountryId);

        public bool IsValid => 
            IsBirthYearValid
            && IsIssueYearValid
            && IsExpirationYearValid 
            && IsHeightValid 
            && IsHairColorValid
            && IsEyeColorValid
            && IsPassportIdValid
            // && IsCountryIdValid
        ;
    }
}