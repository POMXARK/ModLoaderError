using AngleSharp;
using AngleSharp.Dom;
using AngleSharpExtantions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ModLoader
{
    internal class SynthiraRu : BaseParse, IParseConfig, IParseData
    {
        // propfull = быстро создать свойсво

        internal SynthiraRu(string url) : base(url)
        {


        }

        //public string Name{ get => document.QuerySelectorAll(".filekmod .entryLink"); }

        public string DateUpdate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LinkToPageMod { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LinkDownload { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Img { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsUpdate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IHtmlCollection<IElement> Names => FindAll(".filekmod .entryLink");

        public IHtmlCollection<IElement> Descriptions => FindAll(".messzhfg span");

        public string GetData()
        {
            var test = FindAll(".filekmod");
            //test.Html();
            return test.FindAll(".entryLink").Text();
            //var context = BrowsingContext.New(Configuration.Default);
            //var document = await context.OpenAsync(r => r.Content(test.Html()));
            //return document.ToHtml();
        }
    }
}
