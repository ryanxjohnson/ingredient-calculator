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
            var recipe = new RecipeIngredients
            {
                RecipeId = recipeId,
                IngredientId = ingredientId,
                IngredientAmount = ingredientAmount,
                RecipeIngredientUnitId = recipeIngredientUnitId
            };

            Repository.AddRecipeIngredients(recipe);
        }

        public void UpdateData(RecipeIngredients recipeIngredients)
        {
            Repository.UpdateRecipeIngredients(recipeIngredients);
        }
    }
}