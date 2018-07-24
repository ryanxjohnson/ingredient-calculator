using System.Collections.Generic;
using System.Linq;
using IngredientCalculator.Business;
using IngredientCalculator.Factories;
using IngredientCalculator.Models;
using IngredientCalculator.Repositories;
using IngredientCalculator.Services.Units;

namespace IngredientCalculator.ViewModels
{
    public class RecipeViewModel : ViewModelBase<IIngredient>
    {
        public RecipeViewModel() : this(DefaultRepositoryService) { }

        public RecipeViewModel(string repositoryType)
        {
            Repository = RepositoryFactory.GetRecipeRepository(repositoryType);
        }

        public IEnumerable<Recipe> GetRecipesWithCost()
        {
            var recipes = (IEnumerable<Recipe>) new RecipeViewModel().FetchData();

            var recipesWithCost = recipes as Recipe[] ?? recipes.ToArray();
            foreach (var recipe in recipesWithCost)
                recipe.Cost = GetRecipeWithIngredients(recipe.Id).Cost;

            return recipesWithCost;
        }

        public List<Recipe> GetRecipesAndIngredients(int id = 0)
        {
            return new List<Recipe> { GetRecipeWithIngredients(id) };
        }

        public Recipe GetRecipeWithIngredients(int id = 0)
        {
            var recipe = (Recipe)new RecipeViewModel().FetchData(id);
            var recipeIngredients = (IEnumerable<RecipeIngredients>)new RecipeIngredientsViewModel().FetchData(id);

            recipe.RecipeIngredients = Build(recipeIngredients, recipe);
            recipe.Cost = RecipeCostCalculator.CalculateRecipe(recipe.RecipeIngredients);

            return recipe;
        }

        private static List<RecipeIngredientInfo> Build(IEnumerable<RecipeIngredients> recipeIngredients, Recipe recipe)
        {
            return recipeIngredients.Select(
                recipeIngredientsInfo => new RecipeIngredientInfo
                {
                    Recipe = recipe,
                    RecipeId = recipeIngredientsInfo.RecipeId,
                    RecipeIngredientsId = recipeIngredientsInfo.Id,
                    Ingredient = (Ingredient)new IngredientViewModel().FetchData(recipeIngredientsInfo.IngredientId),
                    IngredientAmount = recipeIngredientsInfo.IngredientAmount,
                    Unit = UnitDataService.GetUnits().First(u => u.Id == recipeIngredientsInfo.RecipeIngredientUnitId),
                }).ToList();
        }
    }
}