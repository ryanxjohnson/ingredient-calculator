using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using IngredientCalculator.Models;

namespace IngredientCalculator.Services.Recipes
{
    public class RecipeDataService
    {
        public static IEnumerable<Recipe> GetRecipes()
        {
            var list = new List<Recipe>();
            using (var conn = DataService.CreateConnection())
            {
                var command = new SqlCommand
                {
                    CommandText = "select * from Recipes",
                    Connection = conn
                };

                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Recipe { Id = Convert.ToInt32(reader[0]), RecipeName = reader[1].ToString(), Servings = Convert.ToInt32(reader[2]) });
                    }
                }
            }

            return list;
        }
    }
}