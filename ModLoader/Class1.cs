using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoader
{
    internal class Class1
    {
        public Class1()
        {

        }

        public async Task<string> parseSynthira()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://synthira.ru/";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
            var cells = document.QuerySelectorAll(".filekmod .mvis");
            return cells[0].InnerHtml;
        }
    }
}
