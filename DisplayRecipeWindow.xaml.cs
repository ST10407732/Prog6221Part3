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
        // List to store the recipes
        private List<Recipe> recipes;

        // Constructor for the DisplayRecipeWindow
        public DisplayRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;

            // Populate the ListBox with recipe names sorted alphabetically
            RecipeListBox.ItemsSource = recipes.OrderBy(r => r.RecipeName);
        }

        // Event handler for the "Display Recipe" button click
        private void DisplayRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected recipe from the ListBox
            Recipe selectedRecipe = RecipeListBox.SelectedItem as Recipe;
            if (selectedRecipe == null)
            {
                // Show an error message if no recipe is selected
                MessageBox.Show("Please select a recipe from the list.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Display the details of the selected recipe
            DisplayRecipe(selectedRecipe);
        }

        // Method to display the details of a recipe
        private void DisplayRecipe(Recipe recipe)
        {
            // Clear previous details
            RecipeDetailsTextBlock.Inlines.Clear();

            // Display the recipe name
            Run recipeNameRun = new Run($"Recipe Name: {recipe.RecipeName}\n")
            {
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.DarkBlue
            };
            RecipeDetailsTextBlock.Inlines.Add(recipeNameRun);

            // Display the ingredients header
            RecipeDetailsTextBlock.Inlines.Add(new Run("\nIngredients:\n")
            {
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Green
            });

            // Display each ingredient
            foreach (var ingredient in recipe.Ingredients)
            {
                RecipeDetailsTextBlock.Inlines.Add(new Run($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories) [{ingredient.FoodGroup}]\n"));
            }

            // Display the steps header
            RecipeDetailsTextBlock.Inlines.Add(new Run("\nSteps:\n")
            {
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Blue
            });

            // Display each step
            foreach (var step in recipe.Steps)
            {
                RecipeDetailsTextBlock.Inlines.Add(new Run($"{step}\n"));
            }

            // Calculate the total calories
            int totalCalories = recipe.CalculateTotalCalories();

            // Display the total calories with a warning if it exceeds 300
            string calorieWarning = totalCalories > 300 ? " (Calories exceed 300!)" : "";
            Run totalCaloriesRun = new Run($"\nTotal Calories: {totalCalories}{calorieWarning}")
            {
                FontWeight = FontWeights.Bold,
                Foreground = totalCalories > 300 ? Brushes.Red : Brushes.Black  // Adjust color based on warning
            };
            RecipeDetailsTextBlock.Inlines.Add(totalCaloriesRun);
        }

        // Event handler for the "Back to Menu" button click
        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the current window
            Close();
        }
    }
}
