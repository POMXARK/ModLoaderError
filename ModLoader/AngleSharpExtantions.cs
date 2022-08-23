using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
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

        public static string RemoveTabbing(this string fmt)
        {
            return string.Join(
                System.Environment.NewLine,
                fmt.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(fooline => fooline.Trim()));
        }

        public static string DumpAsYaml(this object o)
            {
                var stringBuilder = new StringBuilder();
                var serializer = new Serializer();
                serializer.Serialize(new IndentedTextWriter(new StringWriter(stringBuilder)), o);
                return stringBuilder.ToString();
            }
        public static string StripHTML(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public static List<DateTime> ParseDate(this string s)
        {
            s = s.ToLower();
            string newStrstr = Regex.Replace(s, " {2,}", " ");//remove more than whitespace
            string newst = Regex.Replace(newStrstr, @"([\s+][-/./_///://|/$/\s+]|[-/./_///://|/$/\s+][\s+])", "/");// remove unwanted whitespace eg 21 -dec- 2017 to 21-07-2017
            newStrstr = newst.Trim();
            Regex rx = new Regex(@"(st|nd|th|rd)");//21st-01-2017 to 21-01-2017
            string sp = rx.Replace(newStrstr, "");
            rx = new Regex(@"(([0-2][0-9]|[3][0-1]|[0-9])[-/./_///://|/$/\s+]([0][0-9]|[0-9]|[1][0-2]|jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec|january|february|march|april|may|june|july|augu|september|october|november|december)[-/./_///:/|/$/\s+][0-9]{2,4})");//a pattern for regex to check date format. For August we check Augu since we replaced the st earlier
            MatchCollection mc = rx.Matches(sp);//look for strings that satisfy the above pattern regex

            List<DateTime> dates = new List<DateTime>(); //Create a list to store the detected dates

            foreach (Match m in mc)
            {
                string s2 = Regex.Replace(m.ToString(), "augu", "august");
                try
                {
                    dates.Add(DateTime.Parse(s2));
                }
                catch (Exception)
                {
                
                }
                
            }

            if (!dates.Any())
            {
                dates.Add(DateTime.Today.AddDays(-1));
            }

            return dates;
        }

        public static IElement Find(this IElement elementHtml, string cssSelectors)
        {return Document(elementHtml).QuerySelector(cssSelectors);}

                public static IElement Find(this IHtmlCollection<IElement> htmlCollection, string cssSelectors)
        {return Document(htmlCollection).QuerySelector(cssSelectors);}

        public static IHtmlCollection<IElement> FindAll(this IElement elementHtml, string cssSelectors)
        {return Document(elementHtml).QuerySelectorAll(cssSelectors);}

        public static IHtmlCollection<IElement> FindAll (this IHtmlCollection<IElement> htmlCollection, string cssSelectors)
        {return Document(htmlCollection).QuerySelectorAll(cssSelectors);}
    }
}
