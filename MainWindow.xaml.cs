using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF_PoePart3
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();
        private List<Recipe> originalRecipes = new List<Recipe>();
        private List<Recipe> filteredRecipes = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow(recipes, originalRecipes);
            addRecipeWindow.ShowDialog();
        }

        private void DisplayRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var displayRecipeWindow = new DisplayRecipeWindow(recipes);
            displayRecipeWindow.ShowDialog();
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var scaleRecipeWindow = new ScaleRecipeWindow(recipes);
            scaleRecipeWindow.ShowDialog();
        }

        private void ResetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            var resetQuantitiesWindow = new ResetQuantitiesWindow(recipes, originalRecipes);
            resetQuantitiesWindow.ShowDialog();
        }

        private void ClearDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("There are no recipes to clear.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to clear all recipe data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ClearAllRecipeData();
                }
            }
        }

        private void ClearAllRecipeData()
        {
            recipes.Clear();
            originalRecipes.Clear();
            MessageBox.Show("All data has been cleared.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DisplayAllRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            var displayAllRecipesWindow = new DisplayAllRecipesWindow(recipes);
            displayAllRecipesWindow.ShowDialog();
        }

        // Filter by Ingredient Name
        private void ApplyIngredientFilter_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = IngredientFilterTextBox.Text.ToLower();

            // Debug: Print out all recipes and their ingredients
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"Recipe: {recipe.RecipeName}");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"Ingredient: {ingredient.Name}");
                }
            }

            // Ensuring that the recipes list is not null or empty
            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                MessageBox.Show("Please enter a valid ingredient name.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Filter recipes that contain the ingredient name
            filteredRecipes = recipes.Where(r => r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredientName))).ToList();

            // Check if any recipes are found
            if (filteredRecipes.Count == 0)
            {
                MessageBox.Show("No recipes found with the specified ingredient.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                DisplayFilteredRecipes();
            }
        

    }

        // Filter by Food Group
        private void ApplyFoodGroupFilter_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = FoodGroupFilterComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Please select a food group.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string selectedFoodGroup = selectedItem.Content.ToString().ToLower();

            filteredRecipes = recipes.Where(r => r.Ingredients.Any(i => i.FoodGroup.ToLower() == selectedFoodGroup)).ToList();

            if (filteredRecipes.Count == 0)
            {
                MessageBox.Show("No recipes found with the specified food group.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                DisplayFilteredRecipes();
            }
        }


        // Filter by Max Calories
        private void ApplyMaxCaloriesFilter_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(MaxCaloriesFilterTextBox.Text, out int maxCalories))
            {
                filteredRecipes = recipes.Where(r => r.CalculateTotalCalories() <= maxCalories).ToList();
                DisplayFilteredRecipes();
            }
            else
            {
                MessageBox.Show("Please enter a valid number for calories.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayFilteredRecipes()
        {
            // Debug: Print out all filtered recipes and their ingredients
            foreach (var recipe in filteredRecipes)
            {
                Console.WriteLine($"Filtered Recipe: {recipe.RecipeName}");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"Filtered Ingredient: {ingredient.Name}");
                }
            }

            var displayAllRecipesWindow = new DisplayAllRecipesWindow(filteredRecipes);
            displayAllRecipesWindow.ShowDialog();
        }

    }
}
