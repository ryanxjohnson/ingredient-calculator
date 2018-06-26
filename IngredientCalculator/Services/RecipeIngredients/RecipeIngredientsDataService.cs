using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IngredientCalculator.Services.RecipeIngredients
{
    public class RecipeIngredientsDataService
    {
        public static IEnumerable<Models.RecipeIngredients> GetRecipeIngredients()
        {
            var list = new List<Models.RecipeIngredients>();
            using (var conn = DataService.CreateConnection())
            {
                var command = new SqlCommand
                {
                    CommandText = "select * from RecipeIngredients",
                    Connection = conn
                };

                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Models.RecipeIngredients
                        {
                            RecipeId = Convert.ToInt32(reader[0]),
                            IngredientId = Convert.ToInt32(reader[1].ToString()),
                            IngredientAmount = Convert.ToDouble(reader[2]),
                            RecipeIngredientUnitId = Convert.ToInt32(reader[3])
                        });
                    }
                }
            }

            return list;
        }
    }
}