using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using IngredientCalculator.Models;
using IngredientCalculator.Services;
using IngredientCalculator.Services.Recipes;

namespace IngredientCalculator.Repositories.Recipes
{
    public class RecipeSqlRepository : IRecipeRepository
    {
        public IEnumerable<Recipe> GetRecipes()
        {
            return RecipeDataService.GetRecipes();
        }

        public Recipe GetRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public void AddRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipe(int id, Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipe(string name)
        {
            throw new NotImplementedException();
        }

        public void AddRecipe(string name, int servings)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = new SqlCommand
                {
                    CommandText = "insert into Recipes (RecipeName, Servings) values (@0, @1)",
                    Connection = conn,
                    Parameters =
                    {
                        new SqlParameter("0", name),
                        new SqlParameter("1", servings)
                    }
                };

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateRecipe(string name, Recipe recipe)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = new SqlCommand
                {
                    CommandText = "update Recipes " +
                                  "set RecipeName = @1 " +
                                  "where Id = @0",
                    Connection = conn,
                    Parameters =
                    {
                        new SqlParameter("0", recipe.Id),
                        new SqlParameter("1", recipe.RecipeName)
                    }
                };

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteRecipe(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipes(IEnumerable<Recipe> recipes)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<object> FetchData()
        {
            return GetRecipes();
        }

        public void AddData(object data)
        {
            throw new NotImplementedException();
        }

        public object FetchData(int id)
        {
            return GetRecipe(id);
        }

        public void UpdateData(object data)
        {
            UpdateRecipe((Recipe)data);
        }

        public void DeleteData(int id)
        {
            throw new NotImplementedException();
        }
    }
}
