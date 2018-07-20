using System.Collections.Generic;
using IngredientCalculator.Repositories;

namespace IngredientCalculator.ViewModels
{
    public abstract class ViewModelBase<T> where T : IIngredient
    {
        // ReSharper disable once StaticMemberInGenericType
        protected static string DefaultRepositoryService = "Sql";

        protected T Repository;

        public string RepositoryType() => Repository.GetType().ToString();

        public IEnumerable<object> Items { get; set; }

        public void AddData(object data)
        {
            Repository.AddData(data);
        }

        public IEnumerable<object> FetchData()
        {
            return Items ?? Repository.FetchData();
        }

        public object FetchData(int id)
        {
            return Repository.FetchData(id);
        }

        public void UpdateData(object data)
        {
            Repository.UpdateData(data);
        }

        public void DeleteData(int id)
        {
            Repository.DeleteData(id);
        }

        public void ClearData()
        {
            Items = new List<object>();
        }
    }
}