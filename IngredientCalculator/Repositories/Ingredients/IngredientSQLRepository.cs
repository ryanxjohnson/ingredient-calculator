using System;
using System.Collections.Generic;
using System.Linq;
using IngredientCalculator.Models;
using IngredientCalculator.Services.Ingredients;

namespace IngredientCalculator.Repositories.Ingredients
{
    public class IngredientSqlRepository : IIngredientRepository
    {
        public IEnumerable<object> FetchData()
        {
            return IngredientDataService.GetIngredients();
        }

        public void AddData(object data)
        {
            IngredientDataService.AddIngredient((Ingredient)data);
        }

        public object FetchData(int id)
        {
            return IngredientDataService.GetIngredients(id).First();
        }

        public void UpdateData(object data)
        {
            IngredientDataService.UpdateIngredient((Ingredient)data);
        }

        public void DeleteData(int id)
        {
            IngredientDataService.DeleteIngredient(id);
        }

        public int GetNumberOfIngredients()
        {
            throw new NotImplementedException();
        }
    }
}
