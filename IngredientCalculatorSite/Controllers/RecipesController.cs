using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IngredientCalculator.Models;
using IngredientCalculator.Repositories.Units;
using IngredientCalculator.ViewModels;

namespace IngredientCalculatorSite.Controllers
{
    public class RecipesController : Controller
    {
        private static RecipeViewModel RecipeViewModel => new RecipeViewModel();

        // GET: Recipes
        public ActionResult Index()
        {
            return View(RecipeViewModel.GetRecipesWithCost());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int id)
        {
            return View(RecipeViewModel.GetRecipeWithIngredients(id));
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var recipe = new Recipe
                {
                    RecipeName = Convert.ToString(collection["RecipeName"]),
                    Servings = Convert.ToInt32(collection["Servings"])
                };

                RecipeViewModel.AddData(recipe);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int id)
        {
            var ings = (IEnumerable<Ingredient>)new IngredientViewModel().FetchData();
            ViewBag.Ingredients = ings;

            ViewBag.Units = new UnitSqlRepository().GetUnits();
            return View(RecipeViewModel.GetRecipeWithIngredients(id));
        }

        // POST: Recipes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var recipe = new Recipe
                {
                    Id = id,
                    RecipeName = Convert.ToString(collection["RecipeName"]),
                    Servings = Convert.ToInt32(collection["Servings"]),
                };

                RecipeViewModel.UpdateData(recipe);

                return RedirectToAction("Edit", "Recipes", new { id });
            }
            catch
            {
                return View("Index", "Index");
            }
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int id)
        {
            return View((Recipe)RecipeViewModel.FetchData(id));
        }

        // POST: Recipes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                RecipeViewModel.DeleteData(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
