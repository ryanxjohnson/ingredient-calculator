using System.Collections.Generic;
using System.Linq;
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

        public List<Recipe> GetRecipesAndIngredients(int id)
        {
            return new List<Recipe> { GetRecipeWithIngredients(id) };
        }

        public Recipe GetRecipeWithIngredients(int id)
        {
            var recipe = (Recipe)new RecipeViewModel().FetchData(id);
            var recipeIngredients = (IEnumerable<RecipeIngredients>)new RecipeIngredientsViewModel().FetchData(id);

            recipe.RecipeIngredients = recipeIngredients.Select(
                recipeIngredientsInfo => new RecipeIngredientInfo
                {
                    RecipeId = recipeIngredientsInfo.RecipeId,
                    RecipeIngredientsId = recipeIngredientsInfo.Id,
                    Ingredient = (Ingredient)new IngredientViewModel().FetchData(recipeIngredientsInfo.IngredientId),
                    IngredientAmount = recipeIngredientsInfo.IngredientAmount,
                    Unit = UnitDataService.GetUnits().First(u => u.Id == recipeIngredientsInfo.RecipeIngredientUnitId),
                    Cost = 1.12m
                }).ToList();

            return recipe;
        }
    }
}