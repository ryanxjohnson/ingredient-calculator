using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using IngredientCalculator.Models;

namespace IngredientCalculator.Services.RecipeCosts
{
    public static class RecipeCostsDataService
    {
        public static IEnumerable<RecipeCost> GetRecipeCosts()
        {
            var list = new List<RecipeComponent>();
            using (var conn = DataService.CreateConnection())
            {
                var cmd = DataService.CreateSqlStoredProcCommand(conn, "sp_GetRecipeComponents");
                var command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,

                    CommandText = "sp_GetRecipeComponents",
                    Connection = conn,
                    Parameters = { new SqlParameter("@RecipeId", "0") }
                };

                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(BuildObject(reader));
                }
            }

            return new List<RecipeCost> { new RecipeCost { Recipe = list.First().Recipe, RecipeComponents = list } };
        }

        public static RecipeCost GetRecipeCost(int id)
        {
            var list = new List<RecipeComponent>();
            using (var conn = DataService.CreateConnection())
            {
                var command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,

                    CommandText = "sp_GetRecipeComponents",
                    Connection = conn,
                    Parameters = { new SqlParameter("@RecipeId", id) }
                };

                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(BuildObject(reader));
                }
            }

            return new RecipeCost { Recipe = list.First().Recipe, RecipeComponents = list };
        }

        private static RecipeComponent BuildObject(IDataRecord reader)
        {
            return new RecipeComponent
            {
                Recipe = new Recipe
                {
                    Id = Convert.ToInt32(reader[0]),
                    Servings = Convert.ToInt32(reader[1])
                },
                IngredientName = Convert.ToString(reader[2]),
                IngredientAmount = Convert.ToDouble(reader[3]),
                ConvertFromUnitName = Convert.ToString(reader[4]),
                CostPerUnit = Convert.ToDecimal(reader[5]),
                ConvertToUnitName = Convert.ToString(reader[6])
            };
        }
    }
}