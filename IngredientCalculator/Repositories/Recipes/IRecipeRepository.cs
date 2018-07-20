using System.Collections.Generic;
using IngredientCalculator.Models;

namespace IngredientCalculator.Repositories.Recipes
{
    public interface IRecipeRepository : IIngredient
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipe(int id);
        void AddRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipe(int id);
        void UpdateRecipes(IEnumerable<Recipe> recipes);
    }
}