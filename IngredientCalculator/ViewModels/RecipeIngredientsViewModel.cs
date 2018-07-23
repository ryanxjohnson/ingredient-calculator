using IngredientCalculator.Factories;
using IngredientCalculator.Repositories.RecipeIngredients;

namespace IngredientCalculator.ViewModels
{
    public class RecipeIngredientsViewModel : ViewModelBase<IRecipeIngredientsRepository>
    {
        public RecipeIngredientsViewModel() : this(DefaultRepositoryService) { }

        public RecipeIngredientsViewModel(string repositoryType)
        {
            Repository = RepositoryFactory.GetRecipeIngredientsRepository(repositoryType);
        }
    }
}