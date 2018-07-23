using System.Collections.Generic;
using IngredientCalculator.Business;
using IngredientCalculator.Models;
using NUnit.Framework;

namespace IngredientCalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private IEnumerable<RecipeCostComponent> recipeComponents;

        [SetUp]
        public void Setup()
        {
            recipeComponents = GetRecipeComponents();
        }

        [Test]
        public void Should_Calculate_Cost_Of_Ingredients()
        {
            Assert.AreEqual(.68m, RecipeCostCalculator.CalculateCostOfIngredients(recipeComponents));
        }

        [Test]
        public void Should_Calulate_Cost_Of_Recipe()
        {
            var rc = new RecipeCost { Recipe = new Recipe{ Id = 1, RecipeName = "Oatmeal with Honey", Servings = 1}, RecipeComponents = recipeComponents };

            Assert.AreEqual(.68m, RecipeCostCalculator.CalculateTotalCost(rc));
        }

        // get this from fake repo
        private static IEnumerable<RecipeCostComponent> GetRecipeComponents()
        {
            return new List<RecipeCostComponent>
            {
                new RecipeCostComponent
                {
                    IngredientName = "Oatmeal",
                    IngredientAmount = .33,
                    ConvertFromUnitName = "cup",
                    CostPerUnit = .18m,
                    ConvertToUnitName = "ounce"
                },
                new RecipeCostComponent
                {
                    IngredientName = "Honey",
                    IngredientAmount = 1,
                    ConvertFromUnitName = "tablespoon",
                    CostPerUnit = .41m,
                    ConvertToUnitName = "ounce"
                }
            };
        }
    }
}