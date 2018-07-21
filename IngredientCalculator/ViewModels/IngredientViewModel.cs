using IngredientCalculator.Factories;
using IngredientCalculator.Repositories;

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