﻿using AngleSharp.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;
using System.Net;

namespace ModLoader
{
    internal class BaseParse: IBaseParse
    {
        protected string url;
        protected IDocument document;
        protected IBrowsingContext context;


        internal BaseParse(string url)
        {
            this.url = url;
            var config = Configuration.Default.WithDefaultLoader();
            context = BrowsingContext.New(config);
            
        }

        public IBrowsingContext Context { get => context;}
        public string Document { get => document.DocumentElement.OuterHtml; }


        public string Url{get => url; set => url = value;}


        async public Task ParseData()
        {
            document = await context.OpenAsync(url);
        }

        public string InnerHtml()
        {

            return "";
        }

    }
}
