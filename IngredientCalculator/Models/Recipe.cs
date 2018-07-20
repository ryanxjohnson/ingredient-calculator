using System.Collections.Generic;

namespace IngredientCalculator.Models
{
    public class Recipe
    {
        public int Id;
        public string RecipeName { get; set; }
        public int Servings { get; set; }

        public List<RecipeIngredientInfo> RecipeIngredients;
    }
}
