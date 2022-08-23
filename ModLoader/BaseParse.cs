using AngleSharp.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;
using System.Net;
using AngleSharp.Html.Parser;

namespace ModLoader
{
    internal class BaseParse:  IBaseParse
    {
        protected IBlockData data;
        protected string url;
        protected IDocument document;
        protected IBrowsingContext context;

        public BaseParse(string url)
        {
            data = Data;
            this.url = url;
            context = BrowsingContext.New(BrowserConfiguration);
        }

        internal BaseParse(string url, IBlockData data)
        {
            this.data = data;
            this.url = url;
            context = BrowsingContext.New(BrowserConfiguration);           
        }

        public IBrowsingContext Context { get => context;}
        public string Document { get => document.DocumentElement.OuterHtml; }


        public string Url{get => url; set => url = value;}

        public HtmlParser Parser => new(new HtmlParserOptions { IsNotConsumingCharacterReferences = true, });

        public IBlockData Data => new BlockData();

        public IConfiguration BrowserConfiguration => Configuration.Default.WithDefaultLoader();

        public IElement Find(string cssSelectors)
        {
            return document.QuerySelector(cssSelectors);
        }

        public IHtmlCollection<IElement> FindAll(string cssSelectors)
        {
            return document.QuerySelectorAll(cssSelectors);
        }

        async public Task ParseData()
        {
            document = await context.OpenAsync(url);
        }


    }
}
