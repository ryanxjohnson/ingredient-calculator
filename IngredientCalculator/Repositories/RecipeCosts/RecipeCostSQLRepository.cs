using System.Collections.Generic;
using System.ComponentModel;
using IngredientCalculator.Models;
using IngredientCalculator.Services.RecipeCosts;

namespace IngredientCalculator.Repositories.RecipeCosts
{
    public class RecipeCostSqlRepository : IRecipeCostsRepository
    {
        public IEnumerable<RecipeCost> GetRecipeCosts()
        {
            return RecipeCostsDataService.GetRecipeCosts();
        }

        public RecipeCost GetRecipeCost(int id)
        {
            return RecipeCostsDataService.GetRecipeCost(id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<object> FetchData()
        {
            return GetRecipeCosts();
        }

        public void AddData(object data)
        {
            throw new System.NotImplementedException();
        }

        public object FetchData(int id)
        {
            return GetRecipeCost(id);
        }

        public void UpdateData(object data)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteData(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
