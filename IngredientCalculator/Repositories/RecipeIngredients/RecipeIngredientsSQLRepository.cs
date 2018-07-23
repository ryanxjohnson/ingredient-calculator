using System.Collections.Generic;
using System.Linq;
using IngredientCalculator.Services.RecipeIngredients;

namespace IngredientCalculator.Repositories.RecipeIngredients
{
    public class RecipeIngredientsSqlRepository : IRecipeIngredientsRepository
    {
        public IEnumerable<object> FetchData()
        {
            return RecipeIngredientsDataService.GetRecipeIngredients();
        }

        public void AddData(object data)
        {
            RecipeIngredientsDataService.AddRecipeIngredients((Models.RecipeIngredients)data);
        }

        public object FetchData(int id)
        {
            return RecipeIngredientsDataService.GetRecipeIngredients(id);
        }

        public void UpdateData(object data)
        {
            RecipeIngredientsDataService.UpdateRecipeIngredients((Models.RecipeIngredients)data);
        }

        public void DeleteData(int id)
        {
            RecipeIngredientsDataService.DeleteRecipeIngredients(id);
        }
    }
}
