using System.Linq;
using System.Web.Mvc;
using Himiya.Models.Entities;

namespace Himiya.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        Store store;
        public AdminController()
        {
            store = new Store();
        }
        public ActionResult Index(int index = 0)
        {
            var list = store.GetGroupsList();
            int c = list.Count()-1;
            if (c < 0) return View();
            if (index < 0) index = c;
            if (index > c) index = 0;
            ViewBag.CurrentNum = index;
            ViewBag.GroupsMaxIndex = c;
            ViewBag.BackLink = Url.Action("Index", "Admin", new { index});
            return View(list.ElementAt(index));
        }

        public ActionResult DetailsTest(int id)
        {
            ViewBag.Title = "Деталі по тесту";
            var test = store.GetTest(id);
            if (test != null)
                return View(test);
            return Redirect(Url.Action("Index"));
        }

        public ActionResult Results()
        {
            return View(store.GetResultsList());
        }

        public ActionResult ClearResults()
        {
            store.ClearResults();
            store.Save();
            return Redirect("Index");
        }
    }
}