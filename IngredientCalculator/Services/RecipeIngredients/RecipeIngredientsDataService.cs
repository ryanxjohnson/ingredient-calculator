using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IngredientCalculator.Services.RecipeIngredients
{
    public class RecipeIngredientsDataService
    {
        public static IEnumerable<Models.RecipeIngredients> GetRecipeIngredients(int recipeId = 0)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_GetRecipeIngredients");
                command.Parameters.Add(new SqlParameter("@RecipeId", recipeId));

                conn.Open();

                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                        yield return BuildRecipeIngredient(reader);
            }
        }

        public static void AddRecipeIngredients(Models.RecipeIngredients recipeIngredients)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_AddRecipeIngredients");
                command.Parameters.Add(new SqlParameter("@RecipeId", recipeIngredients.RecipeId));

                var ingredientId = recipeIngredients.IngredientId == 0 ? 1 : recipeIngredients.IngredientId;
                command.Parameters.Add(new SqlParameter("@IngredientId", ingredientId));
                command.Parameters.Add(new SqlParameter("@IngredientAmount", recipeIngredients.IngredientAmount));
                
                var unitId = recipeIngredients.RecipeIngredientUnitId == 0 ? 1 : recipeIngredients.RecipeIngredientUnitId;
                command.Parameters.Add(new SqlParameter("@IngredientUnitId", unitId ));

                conn.Open();
                command.ExecuteNonQuery();
            }   
        }

        public static void UpdateRecipeIngredients(Models.RecipeIngredients recipeIngredients)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_UpdateRecipeIngredients");
                command.Parameters.Add(new SqlParameter("@Id", recipeIngredients.Id));
                command.Parameters.Add(new SqlParameter("@RecipeId", recipeIngredients.RecipeId));
                command.Parameters.Add(new SqlParameter("@IngredientId", recipeIngredients.IngredientId));
                command.Parameters.Add(new SqlParameter("@IngredientAmount", recipeIngredients.IngredientAmount));
                command.Parameters.Add(new SqlParameter("@IngredientUnitId", recipeIngredients.RecipeIngredientUnitId));

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteRecipeIngredients(int id)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_DeleteRecipeIngredients");
                command.Parameters.Add(new SqlParameter("@Id", id));

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        private static Models.RecipeIngredients BuildRecipeIngredient(IDataRecord reader)
        {
            return new Models.RecipeIngredients
            {
                Id = Convert.ToInt32(reader[0]),
                RecipeId = Convert.ToInt32(reader[1]),
                IngredientId = Convert.ToInt32(reader[2]),
                IngredientAmount = Convert.ToDouble(reader[3]),
                RecipeIngredientUnitId = Convert.ToInt32(reader[4])
            };
        }
    }
}