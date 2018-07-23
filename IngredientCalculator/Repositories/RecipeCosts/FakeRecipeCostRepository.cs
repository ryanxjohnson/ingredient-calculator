using System.Collections.Generic;
using System.ComponentModel;
using IngredientCalculator.Models;

namespace IngredientCalculator.Repositories.RecipeCosts
{
    public class FakeRecipeCostRepository : IRecipeCostsRepository
    {
        public IEnumerable<RecipeCost> GetRecipeCosts()
        {
            return new List<RecipeCost>
            {
                new RecipeCost
                {
                    Recipe = new Recipe
                    {
                        RecipeName = "Oatmeal with Honey",
                        Servings = 1
                    },
                    RecipeComponents = new List<RecipeCostComponent>
                    {
                        new RecipeCostComponent
                        {
                            IngredientName = "Oatmeal",
                            IngredientAmount = .33,
                            ConvertFromUnitName = "cup",
                            CostPerUnit = .18m,
                            ConvertToUnitName = "ounce"
                        },
                        new RecipeCostComponent
                        {
                            IngredientName = "Honey",
                            IngredientAmount = 1,
                            ConvertFromUnitName = "tablespoon",
                            CostPerUnit = .41m,
                            ConvertToUnitName = "ounce"
                        }
                    }
                },
                new RecipeCost
                {
                    Recipe = new Recipe
                    {
                      Id = 2,
                      RecipeName = "Omelet with Goat Cheese",
                      Servings = 1
                    },
                    RecipeComponents = new List<RecipeCostComponent>
                    {
                        new RecipeCostComponent
                        {
                            IngredientName = "Eggs",
                            IngredientAmount = 3,
                            ConvertFromUnitName = "each",
                            CostPerUnit = .17m,
                            ConvertToUnitName = "each"
                        },
                        new RecipeCostComponent
                        {
                            IngredientName = "Honey",
                            IngredientAmount = 1,
                            ConvertFromUnitName = "tablespoon",
                            CostPerUnit = .41m,
                            ConvertToUnitName = "ounce"
                        },
                        new RecipeCostComponent
                        {
                            IngredientName = "Goat Cheese",
                            IngredientAmount = .23,
                            ConvertFromUnitName = "cup",
                            CostPerUnit = 1.43m,
                            ConvertToUnitName = "ounce"
                        }
                    }
                }

            };
        }

        public RecipeCost GetRecipeCost(int id)
        {
            throw new System.NotImplementedException();
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
            
        }

        public void DeleteData(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
