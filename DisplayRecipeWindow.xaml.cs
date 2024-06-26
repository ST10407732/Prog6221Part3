using System.Collections.Generic;
using System.Linq;
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

            // Populate the ListBox with recipe names
            RecipeListBox.ItemsSource = recipes.OrderBy(r => r.RecipeName);
        }

        private void DisplayRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = RecipeListBox.SelectedItem as Recipe;
            if (selectedRecipe == null)
            {
                MessageBox.Show("Please select a recipe from the list.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DisplayRecipe(selectedRecipe);
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
