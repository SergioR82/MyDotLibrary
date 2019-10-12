using MyDotLibrary;
using RecetasMockup.Models;
using System.Web.Mvc;

namespace RecetasMockup.Controllers
{
    public class RecipeTransactionController : BaseController<RecipeTransaction, RecetasMockupContext>
    {
        public ActionResult Index()
        {
            return View("RecipeTransactionViewModel");
        }

        [HttpPost]
        public ActionResult CreateRecipeTransaction(RecipeTransaction recipe)
        {
            base.Create(recipe);
            return View("RecipeTransactionViewModel");
        }
    }
}