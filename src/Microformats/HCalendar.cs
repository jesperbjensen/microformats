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

            Util.AddTagIfValueProvided(veventTag, Css.Summary, Summary);
            Util.AddTagIfValueProvided(veventTag, Css.DateStart, Util.FormatDateTimeValue(DateStart));
            Util.AddTagIfValueProvided(veventTag, Css.DateEnd, Util.FormatDateTimeValue(DateEnd));
            Util.AddTagIfValueProvided(veventTag, Css.Location, Location);
            Util.AddTagIfValueProvided(veventTag, Css.Organizer, Organizer);

            return veventTag.ToString();
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