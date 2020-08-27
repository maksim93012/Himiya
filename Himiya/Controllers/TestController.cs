using Himiya.Models;
using System.Web.Mvc;

namespace Himiya.Controllers
{
    public class TestController : CrUDController<Test>
    {
        public TestController() : base() { }
        public override ActionResult Create(int intoId, string back_link)
        {
            ViewBag.BackLink = back_link;
            ViewBag.GroupId = intoId;
            ViewBag.GroupName = store.GetGroup(intoId).Name;
            return View();
        }
        public override ActionResult Create(Test created, string back_link)
        {
            ViewBag.BackLink = back_link;
            int resId = store.CreateTest(created);
            store.Save();
            return Redirect(back_link);
        }

        public override ActionResult Update(int id, string back_link)
        {
            ViewBag.BackLink = back_link;
            var test = store.GetTest(id);
                if (test != null)
                {
                    return View(test);
                }
            return Redirect(back_link);
        }
        public override ActionResult Update(Test updated, string back_link)
        {
                int resId = store.UpdateTest(updated);
                store.Save();
                return Redirect(Url.Action("DetailsTest","Admin", new { id = resId }));
        }

        public override ActionResult Delete(int id, string back_link)
        {
            var tst = store.GetTest(id);
            ViewBag.Info = "Видалення тесту \"" + tst.Name + "\". Всі питання, які належать до цього тесту також будуть видалені";
            ViewBag.Id = id;
            ViewBag.BackLink = back_link;
            if (tst != null)
                 return View("ConfirmView");
            return Redirect(back_link);
        }
        public override ActionResult Delete(int id, bool cascade, string back_link)
        {
            store.DeleteTest(id);
            store.Save();
            return Redirect(back_link);
        }
    }
}