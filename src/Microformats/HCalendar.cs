using System;
using System.Web;
using System.Web.Mvc;

namespace Microformats
{
    public class HCalendar : IHtmlString
    {
        public string Summary { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }

        #region IHtmlString Members

        public string ToHtmlString()
        {
            return ToString();
        }

        #endregion

        public override string ToString()
        {
            var veventTag = new TagBuilder("div");
            veventTag.AddCssClass(Css.Container);

            AddTagIfValueProvided(veventTag, Css.Summary, Summary);
            AddTagIfValueProvided(veventTag, Css.DateStart, FormatDateTimeValue(DateStart));
            AddTagIfValueProvided(veventTag, Css.DateEnd, FormatDateTimeValue(DateEnd));
            AddTagIfValueProvided(veventTag, Css.Location, Location);
            AddTagIfValueProvided(veventTag, Css.Organizer, Organizer);

            return veventTag.ToString();
        }

        private static void AddTagIfValueProvided(TagBuilder veventTag, string cssClass, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var tag = new TagBuilder("div");
                tag.AddCssClass(cssClass);
                tag.InnerHtml = value;
                veventTag.InnerHtml += tag.ToString();
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

        public static HCalendar Generate(string summary = null, DateTime? dtStart = null,
                                         DateTime? dtEnd = null, string location = null, string organizer = null)
        {
            return new HCalendar
                       {
                           Summary = summary,
                           DateStart = dtStart,
                           DateEnd = dtEnd,
                           Location = location,
                           Organizer = organizer
                       };
        }

        #region Nested type: Css

        public class Css
        {
            public static string Container
            {
                get { return "vevent"; }
            }

            public static string Summary
            {
                get { return "summary"; }
            }

            public static string DateStart
            {
                get { return "dtstart"; }
            }

            public static string DateEnd
            {
                get { return "dtend"; }
            }

            public static string Location
            {
                get { return "location"; }
            }

            public static string Organizer
            {
                get { return "organizer"; }
            }
        }

        #endregion
    }
}