using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace RecipeAppWPF_PoePart3
{
    /// <summary>
    /// Interaction logic for DisplayRecipeWindow.xaml
    /// </summary>
    public partial class DisplayRecipeWindow : Window
    {
      
        private List<Recipe> recipes;

        public DisplayRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
        }

        private void DisplayRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Recipe recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                MessageBox.Show($"Recipe '{recipeName}' not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DisplayRecipe(recipe);
        }

        private void DisplayRecipe(Recipe recipe)
        {
            RecipeDetailsTextBlock.Inlines.Clear();

            // Recipe Name
            Run recipeNameRun = new Run($"Recipe Name: {recipe.RecipeName}\n")
            {
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.DarkBlue
            };
            RecipeDetailsTextBlock.Inlines.Add(recipeNameRun);

            // Ingredients
            RecipeDetailsTextBlock.Inlines.Add(new Run("\nIngredients:\n") { FontWeight = FontWeights.Bold, Foreground = Brushes.Green });
            foreach (var ingredient in recipe.Ingredients)
            {
                RecipeDetailsTextBlock.Inlines.Add(new Run($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories) [{ingredient.FoodGroup}]\n"));
            }

            // Steps
            RecipeDetailsTextBlock.Inlines.Add(new Run("\nSteps:\n") { FontWeight = FontWeights.Bold, Foreground = Brushes.Blue });
            foreach (var step in recipe.Steps)
            {
                RecipeDetailsTextBlock.Inlines.Add(new Run($"{step}\n"));
            }

            // Total Calories with Warning
            int totalCalories = recipe.CalculateTotalCalories();
            string calorieWarning = totalCalories > 300 ? " (Calories exceed 300!)" : "";
            Run totalCaloriesRun = new Run($"\nTotal Calories: {totalCalories}{calorieWarning}")
            {
                FontWeight = FontWeights.Bold,
                Foreground = totalCalories > 300 ? Brushes.Red : Brushes.Black  // Adjust color based on warning
            };
            RecipeDetailsTextBlock.Inlines.Add(totalCaloriesRun);
        }

        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}