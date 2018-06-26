using System;
using System.Collections.Generic;
using System.Linq;
using IngredientCalculator.Models;

namespace IngredientCalculator.Business
{
    public static class RecipeCostCalculator
    {
        public static decimal CalculateTotalCost(RecipeCost recipeCost)
        {
            var costOfIngredients = CalculateCostOfIngredients(recipeCost.RecipeComponents);
            return costOfIngredients * recipeCost.Recipe.Servings;
        }

        public static decimal CalculateCostOfIngredients(IEnumerable<RecipeComponent> recipeComponents)
        {
            return Math.Round(recipeComponents.Sum(r => (decimal) (GetConvertedAmount(r.ConvertFromUnitName, r.ConvertToUnitName, r.IngredientAmount) * (double) r.CostPerUnit)), 2);
        }

        private static double GetConvertedAmount(string convertFromUnitName, string convertToUnitName, double ingredientAmount)
        {
            switch (convertFromUnitName)
            {
                case "cup":
                    switch (convertToUnitName)
                    {
                        case "ounce":
                            return Converters.CupToOunce(ingredientAmount);
                        default:
                            throw new Exception("No valid secondary unit");
                    }
                case "tablespoon":
                    switch (convertToUnitName)
                    {
                        case "ounce":
                            return Converters.TableSpoonToOunce(ingredientAmount);
                        default:
                            throw new Exception("No valid secondary unit");
                    }
                case "teaspoon":
                case "ounce":
                case "each":
                    return ingredientAmount;
                default:
                    throw new Exception("No valid unit");
            }
        }
    }
}