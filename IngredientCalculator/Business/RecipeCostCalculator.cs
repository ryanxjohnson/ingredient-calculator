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

            // test this out
            //return (decimal)GetConvertedAmount(
            //           recipeIngredientInfo.Ingredient.Unit.UnitName,
            //    recipeIngredientInfo.Unit.UnitName,
                       
            //           recipeIngredientInfo.IngredientAmount) * recipeIngredientInfo.Ingredient.CostPerUnit * recipeIngredientInfo.Recipe.Servings;
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
            if (convertFromUnitName == convertToUnitName) return ingredientAmount;

            // TODO: Add grams, particularly for dry measurements ie 25g honeycomb is .88oz / 1 cup
            switch (convertFromUnitName)
            {
                case "cup":
                    return ConvertFromCup(convertToUnitName, ingredientAmount);
                case "tablespoon":
                    return ConvertFromTableSpoon(convertToUnitName, ingredientAmount);
                case "teaspoon":
                    return ConvertFromTeaSpoon(convertToUnitName, ingredientAmount);
                case "ounce":
                    return ConvertFromOunce(convertToUnitName, ingredientAmount);
                case "gram":
                    return ConvertFromGram(convertToUnitName, ingredientAmount);
                case "each":
                    return ingredientAmount;
                default:
                    throw new Exception($"No valid unit: {convertFromUnitName}");
            }
        }

        private static double ConvertFromCup(string convertToUnitName, double ingredientAmount)
        {
            switch (convertToUnitName)
            {
                case "ounce":
                    return Converters.CupToOunce(ingredientAmount);
                default:
                    throw new Exception($"No valid convert to unit: {convertToUnitName}");
            }
        }

        private static double ConvertFromTableSpoon(string convertToUnitName, double ingredientAmount)
        {
            switch (convertToUnitName)
            {
                case "ounce":
                    return Converters.TableSpoonToOunce(ingredientAmount);
                default:
                    throw new Exception($"No valid convert to unit: {convertToUnitName}");
            }
        }

        private static double ConvertFromTeaSpoon(string convertToUnitName, double ingredientAmount)
        {
            var tableSpoon = Converters.TeaSpoonToTableSpoon(ingredientAmount);
            return ConvertFromTableSpoon(convertToUnitName, tableSpoon);
        }

        private static double ConvertFromOunce(string convertToUnitName, double ingredientAmount)
        {
            switch (convertToUnitName)
            {
                case "tablespoon":
                    return Converters.OunceToTableSpoon(ingredientAmount);
                case "cup":
                    return Converters.OunceToCup(ingredientAmount);
                default:
                    throw new Exception($"No valid convert to unit: {convertToUnitName}");
            }
        }

        private static double ConvertFromGram(string convertToUnitName, double ingredientAmount)
        {
            switch (convertToUnitName)
            {
                case "ounce":
                    return Converters.GramToOunce(ingredientAmount);
                case "each":
                    return ingredientAmount;
                default:
                    throw new Exception($"No valid convert to unit: {convertToUnitName}");
            }
        }
    }
}