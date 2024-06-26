using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecipeAppWPF_PoePart3
{
    /// <summary>
    /// Interaction logic for ResetQuantitiesWindow.xaml
    /// </summary>
    public partial class ResetQuantitiesWindow : Window
    {
        private List<Recipe> recipes;
        private List<Recipe> originalRecipes;

        public ResetQuantitiesWindow(List<Recipe> recipes, List<Recipe> originalRecipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            this.originalRecipes = originalRecipes;
        }

        private void ResetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Recipe recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            Recipe originalRecipe = originalRecipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null || originalRecipe == null)
            {
                MessageBox.Show($"Recipe '{recipeName}' not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                recipe.ResetQuantities(originalRecipe.Ingredients.Select(ing =>
                    (ing.Quantity, ing.Unit, ing.Name, ing.Calories)).ToList());
                DisplayResetRecipe(recipe);
                MessageBox.Show("Recipe quantities have been successfully reset.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting quantities: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayResetRecipe(Recipe recipe)
        {
            ResetRecipeDetailsTextBlock.Inlines.Clear();

            // Recipe Name
            Run recipeNameRun = new Run($"Reset Recipe Name: {recipe.RecipeName}\n")
            {
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.DarkBlue
            };
            ResetRecipeDetailsTextBlock.Inlines.Add(recipeNameRun);

            // Ingredients
            ResetRecipeDetailsTextBlock.Inlines.Add(new Run("\nIngredients (Reset):\n") { FontWeight = FontWeights.Bold, Foreground = Brushes.Green });
            foreach (var ingredient in recipe.Ingredients)
            {
                ResetRecipeDetailsTextBlock.Inlines.Add(new Run($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories) [{ingredient.FoodGroup}]\n"));
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}