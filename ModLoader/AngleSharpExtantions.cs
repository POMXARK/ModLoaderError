using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace AngleSharpExtantions
{
    static class AngleSharpExtantions
    {
        private static HtmlParser Parser()
        {return new HtmlParser(new HtmlParserOptions{IsNotConsumingCharacterReferences = true,});}

        private static IDocument Document(this IElement elementHtml)
        { return Parser().ParseDocument(elementHtml.Html());}

        private static IDocument Document(this IHtmlCollection<IElement> elementHtml)
        {return Parser().ParseDocument(elementHtml.Html());}

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
        {return Document(elementHtml).QuerySelector(cssSelectors);}

        public static IElement Find(this IHtmlCollection<IElement> htmlCollection, string cssSelectors)
        { return Document(htmlCollection).QuerySelector(cssSelectors); }

        public static IHtmlCollection<IElement> FindAll(this IElement elementHtml, string cssSelectors)
        {return Document(elementHtml).QuerySelectorAll(cssSelectors);}

        public static IHtmlCollection<IElement> FindAll (this IHtmlCollection<IElement> htmlCollection, string cssSelectors)
        {return Document(htmlCollection).QuerySelectorAll(cssSelectors);}
    }
}
