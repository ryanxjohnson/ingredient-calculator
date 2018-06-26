using System.Collections.Generic;
using IngredientCalculator.Models;

namespace IngredientCalculator.Repositories.Ingredients
{
    public interface IIngredientRepository : IIngredient
    {
        IEnumerable<Ingredient> GetIngredients();
        Ingredient GetIngredient(string name);
        void AddIngredient(string ingredientName, decimal totalPackageCost, double totalPackageVolume, int totalPackageVolumeUnitId, decimal costPerUnit);
        void UpdateIngredient(string name, Ingredient ingredient);
        void DeleteIngredient(string name);
        void UpdateIngredients(IEnumerable<Ingredient> ingredients);
    }
}