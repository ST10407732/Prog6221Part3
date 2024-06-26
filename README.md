Recipe Management Application
Christinah Chitombi
Student Number: ST10407732

Introduction
Sanele's journey into cooking began with Lindiwe's birthday, sparking his passion. This application helps Sanele manage recipes effectively.

Functionality and Features
The Recipe Management Application offers intuitive functions for seamless recipe management:

Entering Recipe Details: Add new recipes with ingredient details.
Displaying Recipes: View recipes with ingredients and their details.
Scaling Recipes: Adjust ingredient quantities based on scaling factors.
Resetting Quantities: Restore ingredient quantities to their original values.
Clearing Data: Remove all recipe data to start fresh.
Procedures to Run the Application

Installation Instructions
Clone the Repository:
Navigate to the Project Directory:
Open the Project:
Open the project in Visual Studio (or your preferred C# IDE).

Restore Dependencies:
Build the solution to ensure all dependencies are installed.

Run the Application:
Run the application through the IDE.

Entering Recipe Details (EnterRecipeDetails Method)
Prompt for Recipe Name: Enter a unique recipe name. Handle invalid or duplicate names.
Prompt for Number of Ingredients: Specify the number of ingredients.
Prompt for Ingredient Details: Enter each ingredient's name, quantity, unit, calories, and food group.
Prompt for Number of Steps: Provide the number of cooking steps.
Displaying Recipe (DisplayRecipe Method)
Displays the recipe name, ingredients with quantities and calories.
Handle cases where no recipe data is available.
Scaling Recipe (ScaleRecipe Method)
Prompts for a scaling factor (0.5, 2, or 3).
Scales ingredient quantities and recalculates calories based on the factor.
Validates input for correct scaling factors.
Class Structure
The application comprises:

Recipe Class: Manages recipe details.
Ingredient Class: Stores ingredient specifics.
Program Class: Entry point of the application.
Error Handling
Validates input for recipe names, ingredient quantities, and scaling factors.
Displays error messages for invalid inputs.
Exiting the Application
Users can exit the application through the interface.

Updates Based on Feedback
Updates Implemented
Enhanced Error Handling: Error messages have been improved to provide clearer guidance during runtime, ensuring better user experience.
Refactored Input Validation: Input validation logic has been refactored into reusable helper methods across relevant parts of the application, enhancing code maintainability and reducing duplication.
Microsoft, 2021. Generic Collections in .NET. [online] Available at: https://learn.microsoft.com/en-us/dotnet/standard/generics/collections [Accessed 30 May 2024].

Rajesh, V. S. (2024, February 29). Exception Handling in C#. C# Corner. Available At: https://www.c-sharpcorner.com/article/exception-handling-in-C-Sharp/ Accessed [(April 13, 2024)].

Ryan, E. (2010, May 7). Units of Measurement Conversion Logic in C#. Stack Overflow. Available at: https://stackoverflow.com/questions/2791724/units-of-measurement-conversion-logic
