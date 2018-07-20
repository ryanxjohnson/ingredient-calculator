using System.Collections.Generic;

namespace IngredientCalculator.Repositories
{
    public interface IIngredient
    {
        IEnumerable<object> FetchData();
        void AddData(object data);
        object FetchData(int id);
        void UpdateData(object data);
        void DeleteData(int id);
    }
}