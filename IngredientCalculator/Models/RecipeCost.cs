using System.Collections.Generic;

namespace IngredientCalculator.Models
{
    public class RecipeCost
    {
        public Recipe Recipe { get; set; }
        public IEnumerable<RecipeCostComponent> RecipeComponents;
    }
}