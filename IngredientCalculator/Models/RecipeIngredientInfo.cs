namespace IngredientCalculator.Models
{
    public class RecipeIngredientInfo
    {
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }

        public int RecipeId { get; set; }
        
        public double IngredientAmount { get; set; }
        public int RecipeIngredientUnitId { get; set; }
        public decimal Cost { get; set; }

        public Unit Unit { get; set; }
        public int RecipeIngredientsId { get; set; }
    }
}
