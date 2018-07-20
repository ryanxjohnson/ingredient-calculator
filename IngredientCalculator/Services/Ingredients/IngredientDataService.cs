using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IngredientCalculator.Models;

namespace IngredientCalculator.Services.Ingredients
{
    public static class IngredientDataService
    {
        public static IEnumerable<Ingredient> GetIngredients(int id = 0)
        {
            using (var conn = DataService.CreateConnection())
            {
                var command = DataService.CreateSqlStoredProcCommand(conn, "sp_GetIngredients");
                command.Parameters.Add(new SqlParameter("@Id", id));

                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return BuildIngredient(reader);
                }
            }
        }

        public static void AddIngredient(Ingredient ingredient)
        {
            using (var conn = DataService.CreateConnection())
            {
                var cmd = DataService.CreateSqlStoredProcCommand(conn, "sp_AddIngredient");
                cmd.Parameters.Add(new SqlParameter("@IngredientName", ingredient.IngredientName));
                cmd.Parameters.Add(new SqlParameter("@IngredientTypeId", ingredient.IngredientTypeId));
                cmd.Parameters.Add(new SqlParameter("@TotalPackageCost", ingredient.TotalPackageCost));
                cmd.Parameters.Add(new SqlParameter("@TotalPackageVolume", ingredient.TotalPackageVolume));
                cmd.Parameters.Add(new SqlParameter("@TotalPackageVolumeUnitId", ingredient.TotalPackageVolumeUnitId));
                cmd.Parameters.Add(new SqlParameter("@CostPerUnit", ingredient.CostPerUnit));
                cmd.Parameters.Add(new SqlParameter("@ExpirationDays", ingredient.ExpirationDays));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateIngredient(Ingredient ingredient)
        {
            using (var conn = DataService.CreateConnection())
            {
                var cmd = DataService.CreateSqlStoredProcCommand(conn, "sp_UpdateIngredient");
                cmd.Parameters.Add(new SqlParameter("@Id", ingredient.Id));
                cmd.Parameters.Add(new SqlParameter("@IngredientName", ingredient.IngredientName));
                cmd.Parameters.Add(new SqlParameter("@IngredientTypeId", ingredient.IngredientTypeId));
                cmd.Parameters.Add(new SqlParameter("@TotalPackageCost", ingredient.TotalPackageCost));
                cmd.Parameters.Add(new SqlParameter("@TotalPackageVolume", ingredient.TotalPackageVolume));
                cmd.Parameters.Add(new SqlParameter("@TotalPackageVolumeUnitId", ingredient.TotalPackageVolumeUnitId));
                cmd.Parameters.Add(new SqlParameter("@CostPerUnit", ingredient.CostPerUnit));
                cmd.Parameters.Add(new SqlParameter("@ExpirationDays", ingredient.ExpirationDays));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteIngredient(int id)
        {
            using (var conn = DataService.CreateConnection())
            {
                var cmd = DataService.CreateSqlStoredProcCommand(conn, "sp_DeleteIngredient");
                cmd.Parameters.Add(new SqlParameter("@Id", id));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static Ingredient BuildIngredient(IDataRecord reader)
        {
            return new Ingredient
            {
                Id = Convert.ToInt32(reader[0]),
                IngredientName = Convert.ToString(reader[1]),
                IngredientType = new IngredientType { Id = Convert.ToInt32(reader[2]), Type = Convert.ToString(reader[3]) },
                IngredientTypeId = Convert.ToInt32(reader[2]),
                TotalPackageCost = Convert.ToDecimal(reader[4]),
                TotalPackageVolume = Convert.ToInt32(reader[5]),
                Unit = new Unit { Id = Convert.ToInt32(reader[6]), UnitName = Convert.ToString(reader[7]) },
                TotalPackageVolumeUnitId = Convert.ToInt32(reader[6]),
                CostPerUnit = Convert.ToDecimal(reader[8]),
                ExpirationDays = reader[9] != DBNull.Value ? Convert.ToInt32(reader[9]) : 0,
            };
        }
    }
}
