using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using Leaf.xNet;
using Parser_WPF.Models;


namespace Parser_WPF
{
    

    public class MemberPage
    {
        private string _response;
        private string _userId;

        enum PageResult { Success, Temeout, NotFound, TooManyPage }

        public MemberPage(string userId)
        {
            _userId = userId;
        }

        
        public string Get()
        {
            _response = "";

            string url = $"https://www.luxuryhomemarketing.com/members/member_{_userId}.html";

            var request = new HttpRequest();

            try
            {
                _response = request.Get(url).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection error: {ex.Message}");
            }

            return _response;
        }

        public Member Parse()
        {
            var parser = new HtmlParser();
            var doc = parser.ParseDocument(_response);

            try
            {
                string memberName = doc.QuerySelector("h1").InnerHtml;
                char[] charsToTrim = { '-', ' ' };
                memberName = memberName.Trim(charsToTrim);

                string email = "";
                string site = "";

                var cells = doc.QuerySelectorAll("p.row.link-list.text-center > a");
                foreach (var cell in cells)
                {
                    string title = cell.TextContent;

                    // найти почту
                    if (title == "Email Me")
                    {
                        email = cell.GetAttribute("href");
                        email = email.Replace("mailto:", "");
                    }

                    // найти сайт
                    if (title == "Visit My Website")
                    {
                        site = cell.GetAttribute("href");
                        site = site.Replace("http://", "");
                    }
                }

                Member member = new Member(_userId, memberName, email, site);
                return member;
            }
            catch (Exception)
            {
            }

            return null;
        }
    }

}
