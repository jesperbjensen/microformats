using System.Web;
using System.Web.Mvc;

namespace Microformats
{
    public class HCard : IHtmlString
    {
        public string Organization { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

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

            Util.AddTagIfValueProvided(hCardTag, Css.FullName, FullName);
            Util.AddTagIfValueProvided(hCardTag, Css.Organization, Organization);
            Util.AddTagIfValueProvided(hCardTag, Css.Email, Email);

            return hCardTag.ToString();
        }


        public static HCard Generate(string fullName = null, string organization = null, string email = null)
        {
            return new HCard
                       {
                           FullName = fullName,
                           Organization = organization,
                           Email = email
                       };
        }

        #region Nested type: Css

        public class Css
        {
            public static string Container
            {
                get { return "vcard"; }
            }

            public static string FullName
            {
                get { return "fn"; }
            }

            public static string Organization
            {
                get { return "org"; }
            }

            public static string Email
            {
                get { return "email"; }
            }
        }

        #endregion
    }
}