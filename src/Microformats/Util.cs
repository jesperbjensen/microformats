using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Microformats
{
    internal class Util
    {
        public static void AddTagIfValueProvided(TagBuilder veventTag, string cssClass, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var tag = new TagBuilder("div");
                tag.AddCssClass(cssClass);
                tag.InnerHtml = value;
                veventTag.InnerHtml += tag.ToString();
            }
        }
    }
}
