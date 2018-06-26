using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using IngredientCalculator.Annotations;
using IngredientCalculator.Repositories;

namespace IngredientCalculator.ViewModels
{
    public abstract class ViewModelBase<T> where T : IIngredient
    {
        // ReSharper disable once StaticMemberInGenericType
        protected static string DefaultRepositoryService = "Sql";

        protected T Repository;

        public string RepositoryType() => Repository.GetType().ToString();

        private IEnumerable<object> items;
        public IEnumerable<object> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public void FetchData()
        {
            Items = Repository.FetchData();
        }

        public void ClearData()
        {
            Items = new List<object>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}