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
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
        private List<Recipe> recipes;
        private List<Recipe> originalRecipes;
        private string recipeName = string.Empty;
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();
        private int currentIngredientIndex = 0;
        private int currentStepIndex = 0;
        private int numIngredients = 0;
        private int numSteps = 0;

        public AddRecipeWindow(List<Recipe> recipes, List<Recipe> originalRecipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            this.originalRecipes = originalRecipes;
        }

        private void NextToIngredients_Click(object sender, RoutedEventArgs e)
        {
            recipeName = RecipeNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(recipeName) || !recipeName.All(char.IsLetter))
            {
                MessageBox.Show("Error: Recipe name cannot be blank and can only contain letters.");
                return;
            }
            if (recipes.Any(r => r.RecipeName == recipeName))
            {
                MessageBox.Show("Error: A recipe with this name already exists. Please enter a different name.");
                return;
            }

            RecipeNameTextBox.IsEnabled = false;
            ((Button)sender).Visibility = Visibility.Collapsed;
            IngredientsPrompt.Visibility = Visibility.Visible;
            NumIngredientsTextBox.Visibility = Visibility.Visible;
            IngredientsNextButton.Visibility = Visibility.Visible;
        }

        private void NextToIngredientDetails_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NumIngredientsTextBox.Text.Trim(), out numIngredients) || numIngredients <= 0)
            {
                MessageBox.Show("Invalid input. Please enter a positive integer for the number of ingredients.");
                return;
            }

            NumIngredientsTextBox.IsEnabled = false;
            IngredientsNextButton.Visibility = Visibility.Collapsed;
            IngredientsDetailsPanel.Visibility = Visibility.Visible;
            UpdateIngredientPrompt();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string name = IngredientNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
            {
                MessageBox.Show($"Error: Ingredient name cannot be blank and can only contain letters.");
                return;
            }

            string[] quantityUnit = IngredientQuantityTextBox.Text.Trim().Split(' ');
            if (quantityUnit.Length < 2 || !double.TryParse(quantityUnit[0], out double quantity) || quantity <= 0)
            {
                MessageBox.Show("Invalid input. Please enter a positive number for quantity followed by the unit of measurement (e.g., 2 tablespoons).");
                return;
            }
            string unit = string.Join(" ", quantityUnit[1..]);

            switch (unit.ToLower())
            {
                case "tablespoons":
                    if (quantity >= 8)
                    {
                        quantity /= 8;
                        unit = "cups";
                    }
                    break;
                case "grams":
                    if (quantity >= 1000)
                    {
                        quantity /= 1000;
                        unit = "kilograms";
                    }
                    break;
            }

            if (!int.TryParse(IngredientCaloriesTextBox.Text.Trim(), out int calories) || calories < 0)
            {
                MessageBox.Show("Invalid input. Please enter a non-negative integer for calories.");
                return;
            }

            string foodGroup = IngredientFoodGroupTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(foodGroup))
            {
                MessageBox.Show("Error: Food group cannot be blank. Please enter a valid food group.");
                return;
            }

            var ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
            ingredients.Add(ingredient);
            // Check total calories
            int totalCalories = ingredients.Sum(i => i.Calories);
            if (totalCalories > 300)
            {
                MessageBox.Show($"Warning: Total calories of ingredients ({totalCalories}) exceed 300.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            currentIngredientIndex++;
            if (currentIngredientIndex >= numIngredients)
            {
                IngredientsDetailsPanel.Visibility = Visibility.Collapsed;
                StepsPrompt.Visibility = Visibility.Visible;
                NumStepsTextBox.Visibility = Visibility.Visible;
                StepsNextButton.Visibility = Visibility.Visible;
            }
            else
            {
                UpdateIngredientPrompt();
            }
        }

        private void NextToStepDetails_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NumStepsTextBox.Text.Trim(), out numSteps) || numSteps <= 0)
            {
                MessageBox.Show("Invalid input. Please enter a positive integer for the number of steps.");
                return;
            }

            NumStepsTextBox.IsEnabled = false;
            StepsNextButton.Visibility = Visibility.Collapsed;
            StepsDetailsPanel.Visibility = Visibility.Visible;
            UpdateStepPrompt();
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            string step = StepTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(step))
            {
                MessageBox.Show("Invalid input. Step cannot be blank. Please enter a valid step.");
                return;
            }

            steps.Add($"Step {currentStepIndex + 1}: {step}");

            currentStepIndex++;
            if (currentStepIndex >= numSteps)
            {
                StepsDetailsPanel.Visibility = Visibility.Collapsed;
                FinishButton.Visibility = Visibility.Visible;
            }
            else
            {
                UpdateStepPrompt();
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            var recipe = new Recipe(recipeName, ingredients, steps);
            recipes.Add(recipe);
            originalRecipes.Add(recipe.Clone());

            MessageBox.Show("Recipe details have been successfully entered.");
            this.Close();
        }

        private void UpdateIngredientPrompt()
        {
            IngredientNamePrompt.Text = $"Enter the name of ingredient {currentIngredientIndex + 1}:";
            IngredientNameTextBox.Clear();
            IngredientQuantityPrompt.Text = $"Enter the quantity and unit of measurement for ingredient {currentIngredientIndex + 1} (e.g., 2 tablespoons):";
            IngredientQuantityTextBox.Clear();
            IngredientCaloriesPrompt.Text = $"Enter the number of calories for ingredient {currentIngredientIndex + 1}:";
            IngredientCaloriesTextBox.Clear();
            IngredientFoodGroupPrompt.Text = $"Enter the food group for ingredient {currentIngredientIndex + 1}:";
            IngredientFoodGroupTextBox.Clear();
        }

        private void UpdateStepPrompt()
        {
            StepPrompt.Text = $"Enter step {currentStepIndex + 1}:";
            StepTextBox.Clear();
        }
    }
}
