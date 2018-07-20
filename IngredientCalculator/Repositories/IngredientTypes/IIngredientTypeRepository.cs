using System.Collections.Generic;
using IngredientCalculator.Models;

namespace IngredientCalculator.Repositories.IngredientTypes
{
    public interface IIngredientTypeRepository
    {
        IEnumerable<IngredientType> GetIngredientTypes();
        void AddIngredientType(IngredientType ingredientType);
        void UpdateIngredientType(int id, IngredientType ingredientType);
        void DeleteIngredientType(int id);
    }
}