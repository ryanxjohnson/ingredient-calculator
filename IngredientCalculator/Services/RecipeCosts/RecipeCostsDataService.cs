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
                    RecipeName = Convert.ToString(reader[1]),
                    Servings = Convert.ToInt32(reader[2])
                },
                IngredientName = Convert.ToString(reader[3]),
                IngredientAmount = Convert.ToDouble(reader[4]),
                ConvertFromUnitName = Convert.ToString(reader[5]),
                CostPerUnit = Convert.ToDecimal(reader[6]),
                ConvertToUnitName = Convert.ToString(reader[7])
            };
        }
    }
}