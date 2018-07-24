using System.Collections.Generic;
using IngredientCalculator.Business;
using IngredientCalculator.Factories;
using IngredientCalculator.Models;
using IngredientCalculator.Repositories.RecipeCosts;

namespace IngredientCalculator.ViewModels
{
    public class RecipeCostViewModel : ViewModelBase<IRecipeCostsRepository>
    {
        public RecipeCostViewModel() : this(DefaultRepositoryService) { }

        public RecipeCostViewModel(string repositoryType)
        {
            Repository = RepositoryFactory.GetRecipeCostsRepository(repositoryType);
        }

        public decimal SumOfAllIngredientsForRecipe(int recipeId)
        {
            var data = (IEnumerable<RecipeCostComponent>)FetchData(recipeId);
            return RecipeCostCalculator.CalculateCostOfIngredients(data);
        }

        public decimal CalculateRecipeCost(Recipe recipe)
        {
            return recipe.Servings * SumOfAllIngredientsForRecipe(recipe.Id);
        }

        public decimal CalculateCostOfSingleIngredientInARecipe(RecipeCostComponent recipeCostComponent)
        {
            return RecipeCostCalculator.CostOfIngredient(recipeCostComponent);
        }
    }
}