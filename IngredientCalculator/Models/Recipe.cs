using System.Collections.Generic;

namespace IngredientCalculator.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public int Servings { get; set; }

        public decimal Cost { get; set; }

        public List<RecipeIngredientInfo> RecipeIngredients;
    }
}
