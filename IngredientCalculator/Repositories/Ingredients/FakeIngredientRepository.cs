using System;
using System.Collections.Generic;
using System.ComponentModel;
using IngredientCalculator.Models;

namespace IngredientCalculator.Repositories.Ingredients
{
    public class FakeIngredientRepository : IIngredientRepository
    {
        public IEnumerable<Ingredient> GetIngredients()
        {
            return new List<Ingredient>
            {
                new Ingredient { Id = 1, IngredientName = "Oatmeal", TotalPackageCost = 4.49m, TotalPackageVolume = 25, TotalPackageVolumeUnitId = 1, CostPerUnit = .18m },
                new Ingredient { Id = 2, IngredientName = "Honey", TotalPackageCost = 6.49m , TotalPackageVolume = 16, TotalPackageVolumeUnitId = 1, CostPerUnit = .41m }
            };
        }

        public Ingredient GetIngredient(int id)
        {
            throw new NotImplementedException();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }


        public void UpdateIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public void UpdateIngredients(IEnumerable<Ingredient> ingredients)
        {
            throw new NotImplementedException();
        }

        public void DeleteIngredient(int id)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<object> FetchData()
        {
            return GetIngredients();
        }

        public void AddData(object data)
        {
            AddIngredient((Ingredient)data);
        }

        public object FetchData(int id)
        {
            return GetIngredient(id);
        }

        public void UpdateData(object data)
        {
            UpdateIngredient((Ingredient)data);
        }

        public void DeleteData(int id)
        {
            DeleteIngredient(id);
        }

        public void UpdateData(int id, object data)
        {
            UpdateIngredient((Ingredient)data);
        }
    }
}
