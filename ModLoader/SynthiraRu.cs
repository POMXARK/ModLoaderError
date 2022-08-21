using AngleSharp;
using AngleSharp.Dom;
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
    internal class SynthiraRu : BaseParse, IParseConfig
    {
        // propfull = быстро создать свойсво
        internal SynthiraRu(string url) : base(url)
        {
            
            //name = document.QuerySelectorAll(".filekmod .mvis")[1].InnerHtml;
        }

        public string Name{ get => document.QuerySelectorAll(".filekmod .mvis")[1].InnerHtml; }

        public string DateUpdate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LinkToPageMod { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LinkDownload { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Img { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsUpdate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        async public void GetData()
        {
            // await ParseData();    
        }
    }
}
