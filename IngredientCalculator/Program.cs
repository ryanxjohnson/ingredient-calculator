using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IngredientCalculator.Business;
using IngredientCalculator.Models;
using IngredientCalculator.Services;
using IngredientCalculator.ViewModels;

namespace IngredientCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Seed();
            //GetSomeData();
        }

        private void Test()
        {
            var ing = new Ingredient {IngredientName = "bread"};
            var list = new List<RecipeIngredientInfo>{new RecipeIngredientInfo{Ingredient = ing, IngredientAmount = 1, RecipeIngredientUnitId = 5}};
            var rec = new Recipe{RecipeName = "toast", RecipeIngredients = list};
        }

        private static void GetSomeData()
        {
            var rcvm = new RecipeCostViewModel(); // readonly
            //rcvm.GetRecipeCost(1);
            PrintData((IEnumerable<RecipeCost>) rcvm.Items);
            rcvm.ClearData();

            Console.WriteLine();

            //rcvm.GetRecipeCost(2);
            PrintData((IEnumerable<RecipeCost>) rcvm.Items);
            rcvm.ClearData();
        }

        private static void PrintData(IEnumerable<RecipeCost> recipeCosts)
        {
            foreach (var o in recipeCosts)
                Console.WriteLine($"Recipe {o.Recipe.RecipeName} | Cost: ${RecipeCostCalculator.CalculateTotalCost(o)}");
        }

        private static void Seed()
        {
            DataService.ClearAllData();
            // Initialize models
            var rvm = new RecipeViewModel();
            var ivm = new IngredientViewModel();
            var rivm = new RecipeIngredientsViewModel();

            // Seed Recipes
            //rvm.AddData("Oatmeal with Honey", 1);
            //rvm.AddData("Omelet with Goat Cheese", 1);

            // Seed Ingredients
            //ivm.AddData("Blueberries", 1.99m, 10, 1, .10m);
            //ivm.AddData("Oatmeal", 4.49m, 24, 1, .18m);
            //ivm.AddData("Honey", 6.49m, 16, 1, .41m);
            //ivm.AddData("Goat Cheese", 4.99m, 3.5, 1, 1.43m);
            //ivm.AddData("Eggs", 2.79m, 12, 5, .23m);

            // Seed Recipe Ingredients
            // Oatmeal
            //rivm.AddData(1, 2, .33, 4); // oatmeal
            //rivm.AddData(1, 3, 1, 2); // honey
            ////Omelet
            //rivm.AddData(2, 3, 1, 2); // honey
            //rivm.AddData(2, 4, .25, 4); // goat cheese
            //rivm.AddData(2, 5, 3, 5); // eggs

            // Populate the models
            ivm.FetchData();
            rvm.FetchData();
            rivm.FetchData();

            // Output Seed Results
            Console.WriteLine("Recipes:");
            foreach (Recipe recipe in rvm.Items)
                Console.WriteLine($"{recipe.RecipeName} | Serves: {recipe.Servings}");

            Console.WriteLine();
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ivm.Items)
                Console.WriteLine(ingredient.IngredientName);

            Console.WriteLine();
            Console.WriteLine("Recipe Ingredients");
            foreach (RecipeIngredients recipeIngredient in rivm.Items)
                Console.WriteLine($"{recipeIngredient.RecipeId}:{recipeIngredient.IngredientId}");
        }
    }
}
