using System.Collections.Generic;
using IngredientCalculator.Models;

namespace IngredientCalculator.Repositories.RecipeCosts
{
    public interface IRecipeCostsRepository : IIngredient
    {
        IEnumerable<RecipeCost> GetRecipeCosts();
        RecipeCost GetRecipeCost(int id);
    }
}