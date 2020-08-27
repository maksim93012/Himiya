using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Himiya.Models
{
    public class AjaxObject
    {
        public string name { get; set; }
        public int duration { get; set; }
        public double priceOfAnswer { get; set; }
        public QuestData[] questions { get; set; }
    }

    public class QuestData
    {
        public string question { get; set; }
        public string answer { get; set; }
        public bool ignoreCase { get; set; }

        public QuestData(string q, string a, bool ic)
        {
            question = q;
            answer = a;
            ignoreCase = ic;
        }
    }
}