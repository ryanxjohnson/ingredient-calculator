using IngredientCalculator.Factories;
using IngredientCalculator.Models;
using IngredientCalculator.Repositories.RecipeIngredients;

namespace IngredientCalculator.ViewModels
{
    public class RecipeIngredientsViewModel : ViewModelBase<IRecipeIngredientsRepository>
    {
        public RecipeIngredientsViewModel() : this(DefaultRepositoryService) { }

        public RecipeIngredientsViewModel(string repositoryType)
        {
            Repository = RepositoryFactory.GetRecipeIngredientsRecipeIngredientsRepository(repositoryType);
        }

        public void AddData(int recipeId, int ingredientId, double ingredientAmount, int recipeIngredientUnitId)
        {
            Repository.AddRecipeIngredients(recipeId, ingredientId, ingredientAmount, recipeIngredientUnitId);
        }

        public void UpdateData(string name, RecipeIngredients recipeIngredients)
        {
            Repository.UpdateRecipeIngredients(name, recipeIngredients);
        }
    }
}