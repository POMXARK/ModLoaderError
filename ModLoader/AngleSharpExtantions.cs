using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace AngleSharpExtantions
{
    static class AngleSharpExtantions
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

        public static IElement Find(this IElement elementHtml, string cssSelectors)
        {
            var parser = new HtmlParser(new HtmlParserOptions
            {
                IsNotConsumingCharacterReferences = true,
            });
            IDocument document = parser.ParseDocument(elementHtml.Html());
            return document.QuerySelector(cssSelectors);
        }

    }
}
