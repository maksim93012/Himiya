using System.Web.Mvc;

namespace Himiya.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString VerifiedAnswer(this HtmlHelper htmlHelper, string answer)
        {
            string result = answer;
            for(int i=1; i<result.Length;i++)
            {
                string substr = result.Substring(i-1, 2);
                if (EnContains(substr) && UkContains(substr))
                {
                    result = result.Replace(substr, $"<span style='color: #f56; background: #000;'>{substr}</span>");
                    break;
                }
            }
            return new MvcHtmlString(result);
        }

        public static bool EnContains(string text)
        {
            foreach(var letter in text)
            {
                if (letter >= 'A' && letter <= 'z') return true;
            }
            return false;
        }
        public static bool UkContains(string text)
        {
            foreach(var letter in text)
            {
                if ((letter >= 'А' && letter <= 'я') || letter == 'і') return true;
            }
            return false;
        }


        public static MvcHtmlString TextWithFormulas(this HtmlHelper htmlHelper, string source)
        {
            string res = "";
            string[] temp = source.Split('[');
            int i;
            if (source[0] == '[')
            {
                i = 0;
            }
            else
            {
                i = 1;
                res += temp[0];
            }
            for (; i < temp.Length; i++)
            {
                int ii = 0;
                for (; ii < temp[i].Length; ii++)
                {
                    if (temp[i][ii] == ']') { ii++; break; }
                    res += WrapInTag(temp[i][ii], "sub");
                }
                res += temp[i].Substring(ii);
            }
            return new MvcHtmlString(res);
        }

        private static string WrapInTag(char letter, string tag)
        {
            return $"<{tag}>{letter}</{tag}>";
        }
    }
}