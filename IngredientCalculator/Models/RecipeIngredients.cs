namespace IngredientCalculator.Models
{
    public class RecipeIngredients
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public double IngredientAmount { get; set; }
        public int RecipeIngredientUnitId { get; set; }
    }
}
