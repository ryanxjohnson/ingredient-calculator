namespace IngredientCalculator.Models
{
    public class Ingredient : SuperItem
    {
        public int Id;
        public string IngredientName { get; set; }
        public decimal TotalPackageCost { get; set; }
        public double TotalPackageVolume { get; set; }
        public int TotalPackageVolumeUnitId { get; set; }
        public decimal CostPerUnit { get; set; }
    }
}
