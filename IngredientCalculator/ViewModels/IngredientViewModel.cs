using IngredientCalculator.Factories;
using IngredientCalculator.Models;
using IngredientCalculator.Repositories.Ingredients;

namespace IngredientCalculator.ViewModels
{
    public class IngredientViewModel : ViewModelBase<IIngredientRepository>
    {
        public IngredientViewModel() : this(DefaultRepositoryService) { }

        public IngredientViewModel(string repositoryType)
        {
            Repository = RepositoryFactory.GetIngredientRepository(repositoryType);
        }

        public void AddData(string ingredientName, decimal totalPackageCost, double totalPackageVolume,
            int totalPackageVolumeUnitId, decimal costPerUnit)
        {
            Repository.AddIngredient(ingredientName, totalPackageCost, totalPackageVolume, totalPackageVolumeUnitId, costPerUnit);
        }

        public void UpdateData(string name, Ingredient ingredient)
        {
            Repository.UpdateIngredient(name, ingredient);
        }
    }
}