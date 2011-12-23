using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Microformats
{
    public class HCard : IHtmlString
    {
        #region IHtmlString Members

        public string ToHtmlString()
        {
            return ToString();
        }

        #endregion

        public override string ToString()
        {
            var hCardTag = new TagBuilder("div");
            hCardTag.AddCssClass(Css.Container);

            return hCardTag.ToString();
        }


        public static HCard Generate()
        {
            return new HCard
            {

            };
        }

        #region Nested type: Css

        public class Css
        {
            public static string Container
            {
                get { return "vcard"; }
            }
        }

        #endregion
    }
}
