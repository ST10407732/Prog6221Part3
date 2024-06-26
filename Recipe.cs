using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppWPF_PoePart3
{

    public class Recipe
    {
       
    public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        // Constructor
        public Recipe(string recipeName, List<Ingredient> ingredients, List<string> steps)
        {
            RecipeName = recipeName;
            Ingredients = ingredients;
            Steps = steps;
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
        }

        // Method to add a step to the recipe
        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        // Method to calculate total calories of the recipe
        public int CalculateTotalCalories()
        {
            int totalCalories = Ingredients.Sum(i => i.Calories);
            return totalCalories;
        }

        // Method to scale the recipe
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
                ingredient.Calories = (int)(ingredient.Calories * factor);
            }
        }

        // Method to reset quantities to original values
        public void ResetQuantities(List<(double, string, string, int)> originalIngredients)
        {
            for (int i = 0; i < originalIngredients.Count; i++)
            {
                var original = originalIngredients[i];
                Ingredients[i].Quantity = original.Item1;
                Ingredients[i].Unit = original.Item2;
                Ingredients[i].Name = original.Item3;
                Ingredients[i].Calories = original.Item4;
            }
        }

        // Method to clear all data from the recipe
        public void ClearData(string recipeName)
        {
            if (ConfirmClear(recipeName))
            {
                Ingredients.Clear();
                Steps.Clear();
                Console.WriteLine($"Recipe '{recipeName}' has been cleared.");
            }
            else
            {
                Console.WriteLine($"Clearing of recipe '{recipeName}' cancelled.");
            }
        }

        // Helper method to confirm clearing of data
        private bool ConfirmClear(string recipeName)
        {
            Console.WriteLine($"Are you sure you want to clear recipe '{recipeName}'? (Y/N)");
            string input = Console.ReadLine()?.Trim().ToUpper();
            return input == "Y";
        }
        public Recipe Clone()
        {
            var clonedIngredients = Ingredients.Select(i => new Ingredient(i.Name, i.Quantity, i.Unit, i.Calories, i.FoodGroup)).ToList();
            var clonedSteps = new List<string>(Steps);
            return new Recipe(RecipeName, clonedIngredients, clonedSteps);
        }
    

    // Override ToString() to display recipe detai
    // ls
    public override string ToString()
        {
            return $"Recipe Name: {RecipeName}, Ingredients: {Ingredients.Count}, Steps: {Steps.Count}";
        }
    }
}
