using System;
using System.Collections.Generic;
using IngredientCalculator.Models;

namespace IngredientCalculator.Services.IngredientTypes
{
    public static class IngredientTypesDataService
    {
        public static IEnumerable<IngredientType> GetIngredientTypes()
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_GetIngredientTypes");

                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return new IngredientType
                        {
                            Id = Convert.ToInt32(reader[0]),
                            Type = Convert.ToString(reader[1]),
                            Description = Convert.ToString(reader[2])
                        };
                }
            }
        }
    }
}
