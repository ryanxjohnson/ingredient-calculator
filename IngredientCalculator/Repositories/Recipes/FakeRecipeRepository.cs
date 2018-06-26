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

        public Recipe GetRecipe(string name)
        {
            throw new NotImplementedException();
        }

        public void AddRecipe(string name, int servings)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipe(string name, Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipe(string name)
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
    }
}
