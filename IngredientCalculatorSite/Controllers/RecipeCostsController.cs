using System.Web.Mvc;
using IngredientCalculator.ViewModels;

namespace IngredientCalculatorSite.Controllers
{
    public class RecipeCostsController : Controller
    {
        private RecipeCostViewModel RecipeCostViewModel => new RecipeCostViewModel();

        // GET: RecipeCosts
        public ActionResult Index()
        {
            var recipeId = 1;
            //var stuff = RecipeCostViewModel.GetCost(recipeId);

            
            return View();
        }

        // GET: RecipeCosts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RecipeCosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeCosts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeCosts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecipeCosts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeCosts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecipeCosts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
