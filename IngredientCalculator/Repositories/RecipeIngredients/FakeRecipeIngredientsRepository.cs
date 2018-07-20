using System.Collections.Generic;
using System.ComponentModel;

namespace IngredientCalculator.Repositories.RecipeIngredients
{
    public class FakeRecipeIngredientsRepository : IRecipeIngredientsRepository
    {
        public IEnumerable<Models.RecipeIngredients> GetRecipeIngredients()
        {
            return new List<Models.RecipeIngredients>
            {
                new Models.RecipeIngredients{ RecipeId = 1, IngredientId = 1, IngredientAmount = .33, RecipeIngredientUnitId = 2 },
                new Models.RecipeIngredients{ RecipeId = 1, IngredientId = 2, IngredientAmount = 1, RecipeIngredientUnitId = 3 }
            };
        }

        public Models.RecipeIngredients GetRecipeIngredients(int id)
        {
            throw new System.NotImplementedException();
        }

        public void AddRecipeIngredients(Models.RecipeIngredients recipeIngredients)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateRecipeIngredients(Models.RecipeIngredients ingredient)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteRecipeIngredients(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateRecipeIngredients(IEnumerable<Models.RecipeIngredients> ingredients)
        {
            throw new System.NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<object> FetchData()
        {
            return GetRecipeIngredients();
        }

        public void AddData(object data)
        {
            throw new System.NotImplementedException();
        }

        public object FetchData(int id)
        {
            return GetRecipeIngredients(id);
        }

        public void UpdateData(object data)
        {
            UpdateRecipeIngredients((Models.RecipeIngredients)data);
        }

        public void DeleteData(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
