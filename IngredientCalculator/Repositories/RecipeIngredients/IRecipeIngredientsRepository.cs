using System.Collections.Generic;

namespace IngredientCalculator.Repositories.RecipeIngredients
{
    public interface IRecipeIngredientsRepository : IIngredient
    {
        IEnumerable<Models.RecipeIngredients> GetRecipeIngredients();
        Models.RecipeIngredients GetRecipeIngredients(int id);
        void AddRecipeIngredients(Models.RecipeIngredients recipeIngredients);
        void UpdateRecipeIngredients(Models.RecipeIngredients ingredient);
        void DeleteRecipeIngredients(int id);
        void UpdateRecipeIngredients(IEnumerable<Models.RecipeIngredients> ingredients);
    }
}