using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using IngredientCalculator.Models;

namespace IngredientCalculator.Services.Ingredients
{
    public static class IngredientDataService
    {
        public static IEnumerable<Ingredient> GetIngredients()
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = new SqlCommand
                {
                    CommandText = "select * from Ingredients",
                    Connection = conn
                };

                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return new Ingredient { Id = Convert.ToInt32(reader[0]), IngredientName = reader[1].ToString(), TotalPackageCost = (decimal)reader[2] };
                }
            }
        }
    }
}