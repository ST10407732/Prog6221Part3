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
    /// Interaction logic for ScaleRecipeWindow.xaml
    /// </summary>
    public partial class ScaleRecipeWindow : Window
    {
        private List<Recipe> recipes;

        public ScaleRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double factor;
            if (!double.TryParse(ScalingFactorTextBox.Text, out factor))
            {
                MessageBox.Show("Invalid input. Please enter a valid scaling factor (e.g., 0.5 for half, 2 for double).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (factor <= 0)
            {
                MessageBox.Show("Scaling factor must be greater than zero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Recipe recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                MessageBox.Show($"Recipe '{recipeName}' not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                recipe.ScaleRecipe(factor);
                DisplayScaledRecipe(recipe);
                MessageBox.Show("Recipe has been successfully scaled.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error scaling recipe '{recipeName}': {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayScaledRecipe(Recipe recipe)
        {
            ScaledRecipeDetailsTextBlock.Inlines.Clear();

            // Recipe Name
            Run recipeNameRun = new Run($"Scaled Recipe Name: {recipe.RecipeName}\n")
            {
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.DarkBlue
            };
            ScaledRecipeDetailsTextBlock.Inlines.Add(recipeNameRun);

            // Ingredients
            ScaledRecipeDetailsTextBlock.Inlines.Add(new Run("\nIngredients (Scaled):\n") { FontWeight = FontWeights.Bold, Foreground = Brushes.Green });
            foreach (var ingredient in recipe.Ingredients)
            {
                ScaledRecipeDetailsTextBlock.Inlines.Add(new Run($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories) [{ingredient.FoodGroup}]\n"));
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}