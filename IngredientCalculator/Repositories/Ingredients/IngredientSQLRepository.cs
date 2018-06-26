using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using IngredientCalculator.Models;
using IngredientCalculator.Services;
using IngredientCalculator.Services.Ingredients;

namespace IngredientCalculator.Repositories.Ingredients
{
    public class IngredientSqlRepository : IIngredientRepository
    {
        public IEnumerable<Ingredient> GetIngredients()
        {
            return IngredientDataService.GetIngredients();
        }

        public Ingredient GetIngredient(string name)
        {
            throw new NotImplementedException();
        }

        public void AddIngredient(string ingredientName, decimal totalPackageCost, double totalPackageVolume,
            int totalPackageVolumeUnitId, decimal costPerUnit)
        {
            var command = new SqlCommand
            {
                CommandText = "insert into Ingredients (IngredientName, TotalPackageCost, TotalPackageVolume, TotalPackageVolumeUnitId,  CostPerUnit) " +
                              "values (@0, @1, @2, @3, @4)",
                Parameters = {
                    new SqlParameter("0", ingredientName),
                    new SqlParameter("1", totalPackageCost),
                    new SqlParameter("2", totalPackageVolume),
                    new SqlParameter("3", totalPackageVolumeUnitId),
                    new SqlParameter("4", costPerUnit)
                }
            };

            DataService.CreateUpdate(command);
        }

        public void UpdateIngredient(string name, Ingredient ingredient)
        {
            var command = new SqlCommand
            {
                CommandText = "update Ingredients " +
                              "set IngredientName = @1, TotalPackageCost = @2, TotalPackageVolume = @3, TotalPackageVolumeUnitId = @4, CostPerUnit = @5 " +
                              "where Id = @0",
                Parameters =
                {
                    new SqlParameter("0", ingredient.Id),
                    new SqlParameter("1", ingredient.IngredientName),
                    new SqlParameter("2", ingredient.TotalPackageCost),
                    new SqlParameter("3", ingredient.TotalPackageVolume),
                    new SqlParameter("4", ingredient.TotalPackageVolumeUnitId),
                    new SqlParameter("5", ingredient.CostPerUnit)
                }
            };

            DataService.CreateUpdate(command);
        }

        public void DeleteIngredient(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateIngredients(IEnumerable<Ingredient> ingredients)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<object> FetchData()
        {
            return GetIngredients();
        }
    }
}
