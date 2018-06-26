using System.Collections.Generic;
using System.ComponentModel;

namespace IngredientCalculator.Repositories
{
    public interface IIngredient : INotifyPropertyChanged
    {
        IEnumerable<object> FetchData();
    }
}