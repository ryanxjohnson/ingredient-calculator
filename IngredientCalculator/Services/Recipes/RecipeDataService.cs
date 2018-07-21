using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IngredientCalculator.Models;

namespace IngredientCalculator.Services.Recipes
{
    public class RecipeDataService
    {
        public static IEnumerable<Recipe> GetRecipes(int id = 0)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_GetRecipes");
                command.Parameters.Add(new SqlParameter("@Id", id));

                conn.Open();

                using (var reader = command.ExecuteReader())
                    while(reader.Read())
                        yield return BuildRecipe(reader);
            }
        }

        public static void AddRecipe(Recipe recipe)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_AddRecipe");
                command.Parameters.Add(new SqlParameter("@RecipeName", recipe.RecipeName));
                command.Parameters.Add(new SqlParameter("@Servings", recipe.Servings));

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateRecipe(Recipe recipe)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_UpdateRecipe");
                command.Parameters.Add(new SqlParameter("@Id", recipe.Id));
                command.Parameters.Add(new SqlParameter("@RecipeName", recipe.RecipeName));
                command.Parameters.Add(new SqlParameter("@Servings", recipe.Servings));

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteRecipe(int id)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_DeleteRecipe");
                command.Parameters.Add(new SqlParameter("@Id", id));

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        private static Recipe BuildRecipe(IDataRecord reader)
        {
            return new Recipe
            {
                Id = Convert.ToInt32(reader[0]),
                RecipeName = Convert.ToString(reader[1]),
                Servings = Convert.ToInt32(reader[2])
            };
        }
    }
}