using IngredientCalculator.Factories;
using IngredientCalculator.Repositories;
using IngredientCalculator.Repositories.Ingredients;

namespace IngredientCalculator.ViewModels
{
    public class IngredientViewModel : ViewModelBase<IIngredient>
    {
        public IngredientViewModel() : this(DefaultRepositoryService) { }

        public IngredientViewModel(string repositoryType)
        {
            Repository = RepositoryFactory.GetIngredientRepository(repositoryType);
        }
    }
}