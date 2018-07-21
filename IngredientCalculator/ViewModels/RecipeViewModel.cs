using IngredientCalculator.Factories;
using IngredientCalculator.Repositories;

namespace IngredientCalculator.ViewModels
{
    public class RecipeViewModel : ViewModelBase<IIngredient>
    {
        public RecipeViewModel() : this(DefaultRepositoryService) { }

        public RecipeViewModel(string repositoryType)
        {
            Repository = RepositoryFactory.GetRecipeRepository(repositoryType);
        }
    }
}