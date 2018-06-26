namespace IngredientCalculator.Models
{
    public class RecipeIngredients
    {
        public int RecipeId;
        public int IngredientId;
        public double IngredientAmount { get; set; }
        public int RecipeIngredientUnitId;
    }
}
