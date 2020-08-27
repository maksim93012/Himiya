using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Himiya.Models;
using System.Text.Json;
using System.Data.Entity;
using Himiya.Models.Entities;
using Himiya.Helpers;

namespace Himiya.Controllers
{
    public class TestingController : Controller
    {
        Store store;
        public TestingController()
        {
            store = new Store();
        }
        public ViewResult Index()
        {
            return View(store.GetGroupsList());
        }

        public ViewResult TestList(int? id)
        {
            ViewBag.GroupName = store.GetGroup((int)id).Name;
            return View(store.GetTestsListByGroup((int)id));
        }

        public ActionResult Test(int? id)
        {
            return View(id);
        }

        [HttpPost]
        public void DataResult(Result result)
        {
            DateTime dt = DateTime.Now;
            result.DateTime = String.Format("{0}.{1}.{2}р.  {3}:{4}",
                dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute);
            store.WriteResult(result);
            store.Save();
        }

        public string DataTest(int id)
        {
            var test = store.GetTest(id);
            var questions = store.GetQuestionsListByTest(id);

            if (questions.Count() < 1) return null;

            int[] indexes = new int[questions.Count()];
            for(int i=0; i<indexes.Length; i++)
            {
                indexes[i] = i;
            }
            Random rnd = new Random();
            for(int i=0; i< indexes.Length; i++)
            {
                int r = rnd.Next(i, indexes.Length);
                int temp = indexes[i];
                indexes[i] = indexes[r];
                indexes[r] = temp;
            }
            QuestData[] q = new QuestData[test.QuestsCount];
            for(int i =0; i<q.Length; i++)
            {
                var t = questions.ElementAt(indexes[i % indexes.Length]);
                t.Quest = Helpers.Helpers.TextWithFormulas(null, t.Quest).ToHtmlString();
                t.Answer = Helpers.Helpers.TextWithFormulas(null, t.Answer).ToHtmlString();
                q[i] = new QuestData(t.Quest, t.Answer, t.IgnoreCase);
            }
            AjaxObject o = new AjaxObject()
            {
                name = test.Name,
                priceOfAnswer = test.PriceForQuest,
                duration = test.Duration,
                questions = q
            };
            return JsonSerializer.Serialize(o, typeof(AjaxObject));
        }
    }
}