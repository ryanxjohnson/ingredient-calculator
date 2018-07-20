using IngredientCalculator.Factories;
using IngredientCalculator.Models;
using IngredientCalculator.Repositories.Recipes;

namespace IngredientCalculator.ViewModels
{
    public class RecipeViewModel : ViewModelBase<IRecipeRepository>
    {
        public RecipeViewModel() : this(DefaultRepositoryService) { }

        public RecipeViewModel(string repositoryType)
        {
            Repository = RepositoryFactory.GetRecipeRepository(repositoryType);
        }

        public void AddData(Recipe recipe)
        {
            Repository.AddRecipe(recipe);
        }

        public void UpdateData(Recipe recipe)
        {
            Repository.UpdateRecipe(recipe);
        }
    }
}