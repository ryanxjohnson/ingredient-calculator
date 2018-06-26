using System.Collections.Generic;
using IngredientCalculator.Models;

namespace IngredientCalculator.Repositories.Recipes
{
    public interface IRecipeRepository : IIngredient
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipe(string name);
        void AddRecipe(string name, int servings);
        void UpdateRecipe(string name, Recipe recipe);
        void DeleteRecipe(string name);
        void UpdateRecipes(IEnumerable<Recipe> recipes);
    }
}