using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeAppWPF_PoePart3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();
        private List<Recipe> originalRecipes = new List<Recipe>();

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
            // Display recipes
            var displayRecipeWindow = new DisplayRecipeWindow(recipes);
            displayRecipeWindow.ShowDialog();
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Scale recipes
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
        
        
    }

    
}