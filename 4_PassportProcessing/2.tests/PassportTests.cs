using System;
using Xunit;
using _4_PassportProcessing_2;

namespace _5_BinaryBoarding_2.Tests
{
    public class PassportTests
    {
        [Fact]
        public void Byr2002()
        {
            var passport = new Passport{ String = "byr:2002" };

            Assert.Equal("2002", passport.BirthYear);
            Assert.True(passport.IsBirthYearValid);
        }

        [Fact]
        public void Byr2003()
        {
            var passport = new Passport{ String = "byr:2003" };

            Assert.Equal("2003", passport.BirthYear);
            Assert.False(passport.IsBirthYearValid);
        }

        [Fact]
        public void Hgt60in()
        {
            var passport = new Passport{ String = "hgt:60in" };

            Assert.Equal("60in", passport.Height);
            Assert.True(passport.IsHeightValid);
        }

        [Fact]
        public void Hgt190cm()
        {
            var passport = new Passport{ String = "hgt:190cm" };

            Assert.Equal("190cm", passport.Height);
            Assert.True(passport.IsHeightValid);
        }

        [Fact]
        public void Hgt190in()
        {
            var passport = new Passport{ String = "hgt:190in" };

            Assert.Equal("190in", passport.Height);
            Assert.False(passport.IsHeightValid);
        }

        [Fact]
        public void Hgt190()
        {
            var passport = new Passport{ String = "hgt:190" };

            Assert.Equal("190", passport.Height);
            Assert.False(passport.IsHeightValid);
        }

        [Fact]
        public void HclDiese123abc()
        {
            var passport = new Passport{ String = "hcl:#123abc" };

            Assert.Equal("#123abc", passport.HairColor);
            Assert.True(passport.IsHairColorValid);
        }

        [Fact]
        public void HclDiese123abz()
        {
            var passport = new Passport{ String = "hcl:#123abz" };

            Assert.Equal("#123abz", passport.HairColor);
            Assert.False(passport.IsHairColorValid);
        }

        [Fact]
        public void Hcl123abc()
        {
            var passport = new Passport{ String = "hcl:123abc" };

            Assert.False(passport.IsHairColorValid);
        }

        [Fact]
        public void EclBrn()
        {
            var passport = new Passport{ String = "ecl:brn" };

            Assert.Equal("brn", passport.EyeColor);
            Assert.True(passport.IsEyeColorValid);
        }

        [Fact]
        public void EclWat()
        {
            var passport = new Passport{ String = "ecl:wat" };

            Assert.Equal("wat", passport.EyeColor);
            Assert.False(passport.IsEyeColorValid);
        }
    }
}
