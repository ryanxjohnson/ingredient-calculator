using System.Collections.Generic;

namespace IngredientCalculator.Repositories.RecipeIngredients
{
    public interface IRecipeIngredientsRepository : IIngredient
    {
        IEnumerable<Models.RecipeIngredients> GetRecipeIngredients();
        Models.RecipeIngredients GetRecipeIngredients(string name);
        void AddRecipeIngredients(int recipeId, int ingredientId, double ingredientAmount, int recipeIngredientUnitId);
        void UpdateRecipeIngredients(string name, Models.RecipeIngredients ingredient);
        void DeleteRecipeIngredients(string name);
        void UpdateRecipeIngredients(IEnumerable<Models.RecipeIngredients> ingredients);
    }
}