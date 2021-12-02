using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using _21_AllergenAssessment_1;

var inputFile = @".\input";

var foods = File
    .ReadAllLines(inputFile)
    .Select(x => new Food(x))
    .ToList();

var allergens = new Dictionary<string,List<string>>();

foreach (var food in foods)
{
    foreach (var allergen in food.Allergens)
    {
        if(! allergens.ContainsKey(allergen)) allergens.Add(allergen, food.Ingredients);

        allergens[allergen] = allergens[allergen].Intersect(food.Ingredients).ToList();
    }
}

var ingredients = foods.SelectMany(x => x.Ingredients).Distinct().ToList();

while(allergens.Count() > 0)
{
    var foundAllergen = allergens.First(x => x.Value.Count == 1);
    var ingredient = foundAllergen.Value.First();
    allergens.Remove(foundAllergen.Key);
    ingredients.Remove(ingredient);
    foreach (var allergen in allergens)
    {
        allergen.Value.Remove(ingredient);
    }
};

var sum = foods.Sum(x => x.Ingredients.Where(y => ingredients.Contains(y)).Count());

Console.WriteLine(sum);
