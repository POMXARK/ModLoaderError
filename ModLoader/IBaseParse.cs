using AngleSharp.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModLoader
{
    internal interface IBaseParse
    {
        Task ParseData();
        IBrowsingContext Context { get;}
        string Document { get;}
        string Url { get; set; }
        IHtmlCollection<IElement> FindAll(string cssSelectors);
        IElement Find(string cssSelectors);
    }
}
