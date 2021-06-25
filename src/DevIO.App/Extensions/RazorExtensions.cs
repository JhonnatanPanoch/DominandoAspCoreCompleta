using Microsoft.AspNetCore.Mvc.Razor;
using System;

namespace DevIO.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormatDocument(this RazorPage page, int type, string doc)
        {
            return type == 1 ? Convert.ToUInt64(doc).ToString(@"000\.000\.000\-00") : 
                Convert.ToUInt64(doc).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
