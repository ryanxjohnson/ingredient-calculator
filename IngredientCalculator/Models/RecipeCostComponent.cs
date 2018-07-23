namespace IngredientCalculator.Models
{
    public class RecipeCostComponent
    {
        public Recipe Recipe { get; set; }
        public string IngredientName { get; set; }
        public double IngredientAmount { get; set; }
        public string ConvertFromUnitName { get; set; }
        public decimal CostPerUnit { get; set; }
        public string ConvertToUnitName { get; set; }
    }
}