using System;
using System.Web;
using System.Web.Mvc;

namespace Microformats
{
    internal class Util
    {
        public static void AddTagIfValueProvided(TagBuilder parentTag, string cssClass, object value)
        {
            string strValue = null;

            if (value != null && !(value is IHtmlString))
                strValue = HttpUtility.HtmlEncode(value.ToString());

            if (value != null && value is IHtmlString)
                strValue = ((IHtmlString) value).ToHtmlString();

            if (!string.IsNullOrWhiteSpace(strValue))
            {
                var tag = new TagBuilder("div");
                tag.AddCssClass(cssClass);
                tag.InnerHtml = strValue;
                parentTag.InnerHtml += tag.ToString();
            }
        }

        public static string FormatDateTimeValue(DateTime? dateStart)
        {
            if (dateStart.HasValue)
            {
                return dateStart.Value.ToUniversalTime().ToString("yyyyMMddTHHmmssZ");
            }

            return null;
        }
    }
}