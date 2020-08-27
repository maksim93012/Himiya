using Himiya.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Himiya.Controllers
{
    public class GroupController : CrUDController<Group>
    {
        public GroupController() : base() { }

        public override ActionResult Create(int intoId, string back_link)
        {
            ViewBag.BackLink = back_link;
            return View();
        }

        public override ActionResult Create(Group created, string back_link)
        {
            store.CreateGroup(created);
            store.Save();
            int groupIndex = store.GetGroupsList().ToList().IndexOf(created);
            return Redirect(Url.Action("Index", "Admin", new { index=groupIndex}));
        }


        public override ActionResult Update(int id, string back_link)
        {
            ViewBag.BackLink = back_link;
            var gr = store.GetGroup(id);
            if (gr != null)
               return View(gr);
            return Redirect(back_link);
        }

        public override ActionResult Update(Group updated, string back_link)
        {
            store.UpdateGroup(updated);
            store.Save();
            return Redirect(back_link);
        }

        public override ActionResult Delete(int id, string back_link)
        {
            var gr = store.GetGroup(id);
            ViewBag.Info = "Видалення групи \"" + gr.Name + "\". Всі тести та питання, " +
                "які належать до групи будуть також знищені";
            ViewBag.Id = id;
            ViewBag.BackLink = back_link;
            if (gr != null)
                return View("ConfirmView");
            return Redirect(back_link);
        }

        public override ActionResult Delete(int id, bool cascade, string back_link)
        {
             store.DeleteGroup(id);
             store.Save();
             return Redirect(Url.Action("Index", "Admin"));
        }
    }
}