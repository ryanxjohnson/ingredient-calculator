using System;
using System.Web.Mvc;
using IngredientCalculator.Models;
using IngredientCalculator.ViewModels;

namespace IngredientCalculatorSite.Controllers
{
    public class RecipeIngredientsController : Controller
    {
        private RecipeIngredientsViewModel RecipeIngredientsViewModel => new RecipeIngredientsViewModel();

        // POST: RecipeIngredients/Edit/5
        [HttpPost]
        public ActionResult Edit(int recipeIngredientsId, FormCollection collection)
        {
            var recipeId = Convert.ToInt32(collection["RecipeId"]);
            try
            {
                var recipeIngredient = new RecipeIngredients
                {
                    Id = recipeIngredientsId,
                    RecipeId = recipeId,
                    IngredientId = Convert.ToInt32(collection["Ingredient.Id"]),
                    IngredientAmount = Convert.ToDouble(collection["IngredientAmount"]),
                    RecipeIngredientUnitId = Convert.ToInt32(collection["Unit.Id"])
                };

                RecipeIngredientsViewModel.UpdateData(recipeIngredient);

                return RedirectToAction("Edit", "Recipes", new { id = recipeId });
            }
            catch
            {
                return RedirectToAction("Edit", "Recipes", new { id = recipeId });
            }
        }

        [HttpPost]
        public ActionResult NewIngredientLineItem(int recipeId)
        {
            RecipeIngredientsViewModel.AddData(new RecipeIngredients { RecipeId = recipeId, IngredientId = 1, IngredientAmount = 0.0, RecipeIngredientUnitId = 1});

            return RedirectToAction("Edit", "Recipes", new { id = recipeId});
        }

        [HttpPost]
        public ActionResult UpdateIngredientLineItem(int recipeIngredientsId, FormCollection collection)
        {
            var recipeId = Convert.ToInt32(collection["RecipeId"]);

            var recipeIngredient = new RecipeIngredients
            {
                Id = recipeIngredientsId,
                RecipeId = Convert.ToInt32(collection["RecipeId"]),
                IngredientId = Convert.ToInt32(collection["IngredientId"]),
                IngredientAmount = Convert.ToDouble(collection["IngredientAmount"]),
                RecipeIngredientUnitId = Convert.ToInt32(collection["RecipeIngredientUnitId"])
            };

            RecipeIngredientsViewModel.UpdateData(recipeIngredient);

            return RedirectToAction("Edit", "Recipes", new { id = recipeId });
        }

        [HttpPost]
        public ActionResult RemoveIngredientLineItem(int recipeIngredientsId, int recipeId)
        {
            RecipeIngredientsViewModel.DeleteData(recipeIngredientsId);

            return RedirectToAction("Edit", "Recipes", new { id = recipeId });
        }
    }
}
