using System;
using System.Collections.Generic;
using System.Linq;

namespace _21_AllergenAssessment_2
{
    public class Food
    {
        public Food(string s)
        {
            Ingredients = s.Split(" (contains ").First().Split(" ").ToList();
            Allergens = s.Split(" (contains ").Last().TrimEnd(')').Split(", ").ToList();
        }

        public List<string> Ingredients { get; set; }
        public List<string> Allergens { get; set; }
    }
}