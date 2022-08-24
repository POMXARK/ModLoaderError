using AngleSharp.Dom;
using AngleSharpExtantions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoader
{
    internal class ContentSynthiraRu : BaseParse
    {
        public ContentSynthiraRu(string url) : base(url)
        { }
        public IHtmlCollection<IElement> Blocks => FindAll(".filekmod");

            public IBlockData[] GetContent()
            {
                var blocks = Blocks;
                IBlockData[] datas = new IBlockData[blocks.Length];
                for (int i = 0; i < blocks.Length; i++)
                {
                    var data = Data;
                    var modInfo = blocks[i].Find(".entryLink");
                    data.Link = modInfo.GetAttribute("href");
                    data.Name = modInfo.Text().RemoveTabbing();
                    data.Description = blocks[i].Find(".messzhfg span").Text();
                    data.DateUpdate = blocks[i].Find(".datemsz").Html().ParseDate();
                    datas[i] = data;
                }
            return datas;//.DumpAsYaml();            
        }

        public async Task<IBlockData> ParsePage(string link, IBlockData data)
        {
            // https://over.wiki/ask/how-to-parse-correctly-using-anglesharp/
            // https://learn.javascript.ru/css-selectors
            SynthiraRu soup = new SynthiraRu(link);
            await soup.ParseData();
            data.LinkDownload = soup.Find(".button28").GetAttribute("href");
            data.AboutMod = soup.Find("#tab1").Html();
            return data;
        }
    }
}
