using System.Collections.Generic;
using System.Linq;
using IngredientCalculator.Models;
using IngredientCalculator.Services.Recipes;

namespace IngredientCalculator.Repositories.Recipes
{
    public class RecipeSqlRepository : IRecipeRepository
    {
        public IEnumerable<object> FetchData()
        {
            return RecipeDataService.GetRecipes();
        }

        public void AddData(object data)
        {
            RecipeDataService.AddRecipe((Recipe)data);
        }

        public object FetchData(int id)
        {
            return RecipeDataService.GetRecipes(id).First();
        }

        public void UpdateData(object data)
        {
            RecipeDataService.UpdateRecipe((Recipe)data);
        }

        public void DeleteData(int id)
        {
            RecipeDataService.DeleteRecipe(id);
        }
    }
}
