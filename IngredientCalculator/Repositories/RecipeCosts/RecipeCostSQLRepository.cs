using System.Collections.Generic;
using IngredientCalculator.Services.RecipeCosts;

namespace IngredientCalculator.Repositories.RecipeCosts
{
    public class RecipeCostSqlRepository : IRecipeCostsRepository
    {
        public IEnumerable<object> FetchData()
        {
            return RecipeCostsDataService.GetRecipeCosts();
        }

        public object FetchData(int id)
        {
            return RecipeCostsDataService.GetRecipeCosts(id);
        }

        #region not implemented
        public void AddData(object data)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateData(object data)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteData(int id)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
