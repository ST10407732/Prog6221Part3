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
    /// Interaction logic for DisplayAllRecipesWindow.xaml
    /// </summary>
    public partial class DisplayAllRecipesWindow : Window
    {
        private List<Recipe> recipes;

        public DisplayAllRecipesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            DisplayRecipes();
        }

        private void DisplayRecipes()
        {
            RecipesStackPanel.Children.Clear();

            foreach (var recipe in recipes)
            {
                Border recipeBorder = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(5),
                    Padding = new Thickness(10),
                    Background = Brushes.White,
                };

                StackPanel recipePanel = new StackPanel();

                // Recipe Name
                TextBlock recipeNameTextBlock = new TextBlock
                {
                    Text = $"Recipe Name: {recipe.RecipeName}",
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.DarkBlue,
                    FontSize = 16
                };
                recipePanel.Children.Add(recipeNameTextBlock);

                // Ingredients
                TextBlock ingredientsHeader = new TextBlock
                {
                    Text = "\nIngredients:",
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.Green,
                    FontSize = 14
                };
                recipePanel.Children.Add(ingredientsHeader);

                foreach (var ingredient in recipe.Ingredients)
                {
                    TextBlock ingredientTextBlock = new TextBlock
                    {
                        Text = $"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories) [{ingredient.FoodGroup}]"
                    };
                    recipePanel.Children.Add(ingredientTextBlock);
                }

                // Steps
                TextBlock stepsHeader = new TextBlock
                {
                    Text = "\nSteps:",
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.Purple,
                    FontSize = 14
                };
                recipePanel.Children.Add(stepsHeader);

                foreach (var step in recipe.Steps)
                {
                    TextBlock stepTextBlock = new TextBlock
                    {
                        Text = $"{step}"
                    };
                    recipePanel.Children.Add(stepTextBlock);
                }

                // Total Calories with Warning
                int totalCalories = recipe.CalculateTotalCalories();
                string calorieWarning = totalCalories > 300 ? " (Calories exceed 300!)" : "";
                TextBlock totalCaloriesTextBlock = new TextBlock
                {
                    Text = $"\nTotal Calories: {totalCalories}{calorieWarning}",
                    FontWeight = FontWeights.Bold,
                    Foreground = totalCalories > 300 ? Brushes.Red : Brushes.Black,  // Adjust color based on warning
                    FontSize = 14
                };
                recipePanel.Children.Add(totalCaloriesTextBlock);

                recipeBorder.Child = recipePanel;
                RecipesStackPanel.Children.Add(recipeBorder);
            }
        }


        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}