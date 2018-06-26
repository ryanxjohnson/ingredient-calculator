﻿using System.Collections.Generic;
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
                    RecipeComponents = new List<RecipeComponent>
                    {
                        new RecipeComponent
                        {
                            IngredientName = "Oatmeal",
                            IngredientAmount = .33,
                            ConvertFromUnitName = "cup",
                            CostPerUnit = .18m,
                            ConvertToUnitName = "ounce"
                        },
                        new RecipeComponent
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
                    RecipeComponents = new List<RecipeComponent>
                    {
                        new RecipeComponent
                        {
                            IngredientName = "Eggs",
                            IngredientAmount = 3,
                            ConvertFromUnitName = "each",
                            CostPerUnit = .17m,
                            ConvertToUnitName = "each"
                        },
                        new RecipeComponent
                        {
                            IngredientName = "Honey",
                            IngredientAmount = 1,
                            ConvertFromUnitName = "tablespoon",
                            CostPerUnit = .41m,
                            ConvertToUnitName = "ounce"
                        },
                        new RecipeComponent
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
    }
}
