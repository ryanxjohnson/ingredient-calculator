using System.Web.Mvc;

namespace IngredientCalculator.Models
{
    public class Ingredient
    {
        public int Id;
        public string IngredientName { get; set; }
        public int IngredientTypeId { get; set; }
        public decimal TotalPackageCost { get; set; }
        public double TotalPackageVolume { get; set; }
        public int TotalPackageVolumeUnitId { get; set; }
        public decimal CostPerUnit { get; set; }
        public int ExpirationDays { get; set; }

        public IngredientType IngredientType;
        public Unit Unit;

        public SelectList UnitDropDownList;
        public SelectList IngredientTypeDropDownList;
    }
}
