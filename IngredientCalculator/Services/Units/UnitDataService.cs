using System;
using IngredientCalculator.Models;
using System.Collections.Generic;

namespace IngredientCalculator.Services.Units
{
    public static class UnitDataService
    {
        public static IEnumerable<Unit> GetUnits()
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_GetUnits");
                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return new Unit
                        {
                            Id = Convert.ToInt32(reader[0]),
                            UnitName = Convert.ToString(reader[1])
                        };
                }
            }
        }
    }
}
