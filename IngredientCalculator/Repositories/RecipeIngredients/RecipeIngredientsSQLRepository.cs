using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using IngredientCalculator.Services;
using IngredientCalculator.Services.RecipeIngredients;

namespace IngredientCalculator.Repositories.RecipeIngredients
{
    public class RecipeIngredientsSqlRepository : IRecipeIngredientsRepository
    {
        public IEnumerable<Models.RecipeIngredients> GetRecipeIngredients()
        {
            return RecipeIngredientsDataService.GetRecipeIngredients();
        }

        public Models.RecipeIngredients GetRecipeIngredients(string recipeName)
        {
            throw new NotImplementedException();
        }

        public void AddRecipeIngredients(int recipeId, int ingredientId, double ingredientAmount, int recipeIngredientUnitId)
        {
            var command = new SqlCommand
            {
                CommandText = "insert into RecipeIngredients (RecipeId, IngredientId, IngredientAmount, IngredientUnitId) " +
                              "values (@0, @1, @2, @3)",
                Parameters = {
                    new SqlParameter("0", recipeId),
                    new SqlParameter("1", ingredientId),
                    new SqlParameter("2", ingredientAmount),
                    new SqlParameter("3", recipeIngredientUnitId)
                }
            };

            DataService.CreateUpdate(command);
        }

        public void UpdateRecipeIngredients(string name, Models.RecipeIngredients recipeIngredients)
        {
            var command = new SqlCommand
            {
                CommandText = "update RecipeIngredients  " +
                              "set (RecipeId = @0, IngredientId = @1, IngredientAmount = @2, IngredientUnitId = @3)",
                Parameters = {
                    new SqlParameter("0", recipeIngredients.RecipeId),
                    new SqlParameter("1", recipeIngredients.IngredientId),
                    new SqlParameter("2", recipeIngredients.IngredientAmount),
                    new SqlParameter("3", recipeIngredients.RecipeIngredientUnitId)
                }
            };
            
            DataService.CreateUpdate(command);
        }

        public void DeleteRecipeIngredients(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipeIngredients(IEnumerable<Models.RecipeIngredients> ingredients)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<object> FetchData()
        {
            return GetRecipeIngredients();
        }
    }
}
