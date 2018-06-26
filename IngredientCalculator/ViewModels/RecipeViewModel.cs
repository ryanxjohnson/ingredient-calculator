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

        public void AddData(string name, int servings)
        {
            Repository.AddRecipe(name, servings);
        }

        public void UpdateData(string name, Recipe recipe)
        {
            Repository.UpdateRecipe(name, recipe);
        }
    }
}