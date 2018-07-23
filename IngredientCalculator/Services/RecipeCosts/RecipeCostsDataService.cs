using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IngredientCalculator.Models;

namespace IngredientCalculator.Services.RecipeCosts
{
    public static class RecipeCostsDataService
    {
        public static IEnumerable<RecipeCostComponent> GetRecipeCosts(int id = 0)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_GetRecipeCosts");
                command.Parameters.Add(new SqlParameter("@RecipeId", id));

                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return BuildObject(reader);
                    }
                }
            }
        }

        private static RecipeCostComponent BuildObject(IDataRecord reader)
        {
            return new RecipeCostComponent
            {
                Recipe = new Recipe
                {
                  Id  = Convert.ToInt32(reader[0]),
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