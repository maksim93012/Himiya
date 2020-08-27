using Himiya.Models;
using System.Web.Mvc;

namespace Himiya.Controllers
{
    public class QuestionController : CrUDController<Question>
    {
        public QuestionController() : base() { }
        public override ActionResult Create(int intoId, string back_link)
        {
            ViewBag.BackLink = back_link;
            var test = store.GetTest(intoId);
            if (test != null)
            {
                ViewBag.TestName = test.Name;
                ViewBag.TestId = test.Id;
                return View();
            }
            return Redirect(back_link);
        }
        public override ActionResult Create(Question created, string back_link)
        {
            store.CreateQuestion(created);
            store.Save();
            return Redirect(back_link);
        }
        public override ActionResult Update(int id, string back_link)
        {
            ViewBag.BackLink = back_link;
            var q = store.GetQuestion(id);
            if (q != null)
            {   
                return View(q);
            }
            return RedirectToAction(back_link);
        }
        public override ActionResult Update(Question updated, string back_link)
        {
                store.UpdateQuestion(updated);
                store.Save();
                return Redirect(back_link);
        }
        public override ActionResult Delete(int id, string back_link)
        {
            var qst = store.GetQuestion(id);
            ViewBag.Info = "Видалення питання \"" + qst.Quest + "\"";
            ViewBag.Id = id;
            ViewBag.BackLink = back_link;
            if (qst != null)
                return View("ConfirmView");
            return Redirect(back_link);
        }
        public override ActionResult Delete(int id, bool cascade, string back_link)
        {
            store.DeleteQuestion(id);
            store.Save();
            return Redirect(back_link);
        }
    }
}