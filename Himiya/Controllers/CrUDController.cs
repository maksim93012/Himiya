using Himiya.Models.Abstract;
using Himiya.Models.Entities;
using System.Web.Mvc;

namespace Himiya.Controllers
{
    [Authorize]
    public abstract class CrUDController<T> : Controller where T:class
    {
        protected IStore store;
        protected CrUDController()
        {
            store = new Store();
        }
        [HttpGet]
        public abstract ActionResult Create(int intoId, string back_link);
        [HttpPost]
        public abstract ActionResult Create(T created, string back_link);
        [HttpGet]
        public abstract ActionResult Update(int id, string back_link);
        [HttpPost]
        public abstract ActionResult Update(T updated, string back_link);
        [HttpGet]
        public abstract ActionResult Delete(int id, string back_link);
        [HttpPost]
        public abstract ActionResult Delete(int id, bool cascade, string back_link);
    }
}