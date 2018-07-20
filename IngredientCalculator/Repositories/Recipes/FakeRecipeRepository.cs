using System;
using System.Collections.Generic;
using System.ComponentModel;
using IngredientCalculator.Models;

namespace IngredientCalculator.Repositories.Recipes
{
    public class FakeRecipeRepository : IRecipeRepository
    {
        public IEnumerable<Recipe> GetRecipes()
        {
            return new List<Recipe>
            {
                new Recipe{Id = 1, RecipeName = "Oatmeal with Honey"}
            };
        }

        public Recipe GetRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public void AddRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipes(IEnumerable<Recipe> recipes)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<object> FetchData()
        {
            return GetRecipes();
        }

        public void AddData(object data)
        {
            throw new NotImplementedException();
        }

        public object FetchData(int id)
        {
            return GetRecipe(id);
        }

        public void UpdateData(object data)
        {
            UpdateRecipe((Recipe)data);
        }

        public void DeleteData(int id)
        {
            throw new NotImplementedException();
        }
    }
}
