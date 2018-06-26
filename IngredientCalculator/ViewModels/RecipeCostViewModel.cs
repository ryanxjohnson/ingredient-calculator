using System.Collections.Generic;
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

        public void GetRecipeCost(int id)
        {
            Items = new List<RecipeCost>{ Repository.GetRecipeCost(id) };
        }
    }
}