using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IngredientCalculator.Models;
using IngredientCalculator.Repositories.IngredientTypes;
using IngredientCalculator.Repositories.Units;
using IngredientCalculator.ViewModels;

namespace IngredientCalculatorSite.Controllers
{
    public class IngredientsController : Controller
    {
        private static IngredientViewModel IngredientViewModel => new IngredientViewModel();

        // GET: Ingredients
        public ActionResult Index()
        {
            return View((IEnumerable<Ingredient>)IngredientViewModel.FetchData());
        }

        //// GET: Ingredients/Details/5
        public ActionResult Details(int id)
        {
            return View((Ingredient)IngredientViewModel.FetchData(id));
        }

        //// GET: Ingredients/Create
        public ActionResult Create()
        {
            AddUnitsAndTypesToViewBag();

            return View();
        }

        //// POST: Ingredients/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var ingredient = new Ingredient
                {
                    IngredientName = collection["IngredientName"],
                    IngredientTypeId = Convert.ToInt32(collection["IngredientTypeDropDownList"]),
                    TotalPackageCost = Convert.ToDecimal(collection["TotalPackageCost"]),
                    TotalPackageVolume = Convert.ToInt32(collection["TotalPackageVolume"]),
                    TotalPackageVolumeUnitId = Convert.ToInt32(collection["UnitDropDownList"]),
                    CostPerUnit = Convert.ToDecimal(collection["CostPerUnit"]),
                    ExpirationDays = Convert.ToInt32(collection["ExpirationDays"])
                };

                IngredientViewModel.AddData(ingredient);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Ingredients/Edit/5
        public ActionResult Edit(int id)
        {
            AddUnitsAndTypesToViewBag();

            return View((Ingredient)IngredientViewModel.FetchData(id));
        }

        //// POST: Ingredients/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var ingredient = new Ingredient
                {
                    Id = id,
                    IngredientName = Convert.ToString(collection["IngredientName"]),
                    IngredientTypeId = Convert.ToInt32(collection["IngredientTypeId"]),
                    TotalPackageCost = Convert.ToDecimal(collection["TotalPackageCost"]),
                    TotalPackageVolume = Convert.ToInt32(collection["TotalPackageVolume"]),
                    TotalPackageVolumeUnitId = Convert.ToInt32(collection["TotalPackageVolumeUnitId"]),
                    CostPerUnit = Convert.ToDecimal(collection["CostPerUnit"]),
                    ExpirationDays = Convert.ToInt32(collection["ExpirationDays"])
                };

                IngredientViewModel.UpdateData(ingredient);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Ingredients/Delete/5
        public ActionResult Delete(int id)
        {
            return View((Ingredient)IngredientViewModel.FetchData(id));
        }

        //// POST: Ingredients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                IngredientViewModel.DeleteData(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void AddUnitsAndTypesToViewBag()
        {
            ViewBag.Units = new UnitSqlRepository().GetUnits();
            ViewBag.IngredientTypes = new IngredientTypeSqlRepository().GetIngredientTypes();
        }
    }
}
