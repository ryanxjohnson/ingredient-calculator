namespace IngredientCalculator.Models
{
    public class RecipeIngredients
    {
        public int RecipeId;
        public int IngredientId;
        public double IngredientAmount { get; set; }
        public int RecipeIngredientUnitId;
    }

    public class RecipeIngredientInfo
    {
        public Ingredient Ingredient { get; set; }
        public double IngredientAmount { get; set; }
        public int RecipeIngredientUnitId { get; set; }
    }
}
