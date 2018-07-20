using System;
using System.Collections.Generic;
using IngredientCalculator.Models;
using IngredientCalculator.Services.IngredientTypes;

namespace IngredientCalculator.Repositories.IngredientTypes
{
    public class IngredientTypeSqlRepository : IIngredientTypeRepository
    {
        public IEnumerable<IngredientType> GetIngredientTypes()
        {
            return IngredientTypesDataService.GetIngredientTypes();
        }

        public void AddIngredientType(IngredientType ingredientType)
        {
            throw new NotImplementedException();
        }

        public void UpdateIngredientType(int id, IngredientType ingredientType)
        {
            throw new NotImplementedException();
        }

        public void DeleteIngredientType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
