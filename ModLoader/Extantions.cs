using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModLoader
{
    static class Extantions
    {
        public static string Text(this IHtmlCollection<IElement> htmlCollection)
        {
            List<string> temp = new List<string>();
            foreach (var item in htmlCollection)
            {
                temp.Add(item.InnerHtml);
            }
            return string.Join(", ", temp.ToArray());
        }

        public static string Html(this IHtmlCollection<IElement> htmlCollection)
        {
            List<string> temp = new List<string>();
            foreach (var item in htmlCollection)
            {
                temp.Add(item.OuterHtml);
            }
            return string.Join(", ", temp.ToArray());
        }
    }
}
