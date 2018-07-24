using System;
using System.Collections.Generic;
using System.Linq;
using IngredientCalculator.Models;

namespace IngredientCalculator.Business
{
    public static class RecipeCostCalculator
    {
        public static decimal Calculate(this RecipeIngredientInfo recipeIngredientInfo)
        {
            return (decimal)GetConvertedAmount(
                recipeIngredientInfo.Unit.UnitName,
                recipeIngredientInfo.Ingredient.Unit.UnitName,
                recipeIngredientInfo.IngredientAmount) * recipeIngredientInfo.Ingredient.CostPerUnit * recipeIngredientInfo.Recipe.Servings;
        }

        public static decimal CalculateRecipe(IEnumerable<RecipeIngredientInfo> recipeIngredientInfos)
        {
            return recipeIngredientInfos.Sum(recipeIngredientInfo => recipeIngredientInfo.Cost = recipeIngredientInfo.Calculate());
        }
        
        public static decimal CalculateTotalCost(RecipeCost recipeCost)
        {
            var costOfIngredients = CalculateCostOfIngredients(recipeCost.RecipeComponents);
            return costOfIngredients * recipeCost.Recipe.Servings;
        }

        public static decimal CalculateCostOfIngredients(IEnumerable<RecipeCostComponent> recipeComponents)
        {
            var sum = recipeComponents.Sum(r => CostOfIngredient(r));

            return Math.Round(sum, 2);
        }

        public static decimal CostOfIngredient(RecipeCostComponent r)
        {
            return (decimal)(GetConvertedAmount(r.ConvertFromUnitName, r.ConvertToUnitName, r.IngredientAmount) * (double) r.CostPerUnit);
        }

        private static double GetConvertedAmount(string convertFromUnitName, string convertToUnitName, double ingredientAmount)
        {
            if (convertFromUnitName == convertToUnitName) return 1;

            // TODO: Add grams, particularly for dry measurements ie 25g honeycomb is .88oz / 1 cup
            switch (convertFromUnitName)
            {
                case "cup":
                    switch (convertToUnitName)
                    {
                        case "ounce":
                            return Converters.CupToOunce(ingredientAmount);
                        default:
                            throw new Exception($"No valid convert to unit: {convertToUnitName}");
                    }
                case "tablespoon":
                    switch (convertToUnitName)
                    {
                        case "ounce":
                            return Converters.TableSpoonToOunce(ingredientAmount);
                        default:
                            throw new Exception($"No valid convert to unit: {convertToUnitName}");
                    }
                case "teaspoon":
                case "ounce":
                    switch (convertToUnitName)
                    {
                        case "tablespoon":
                            return Converters.OunceToTableSpoon(ingredientAmount);
                        case "cup":
                            return Converters.OunceToCup(ingredientAmount);
                        default:
                            throw new Exception($"No valid convert to unit: {convertToUnitName}");
                    }
                case "gram":
                    switch (convertToUnitName)
                    {
                        case "ounce":
                            return Converters.GramToOunce(ingredientAmount);
                        default:
                            throw new Exception($"No valid convert to unit: {convertToUnitName}");
                    }
                case "each":
                    return ingredientAmount;
                default:
                    throw new Exception($"No valid unit: {convertFromUnitName}");
            }
        }
    }
}