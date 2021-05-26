using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AngleSharp.Html.Parser;
using Leaf.xNet;
using Parser_WPF.Interfaces;
using Parser_WPF.Models;

namespace Parser_WPF
{
    enum MemberLevel { mlMember, mlCLHMS, mlGuild, mlAffiliate }

    public class SearchPage : ISearchPage
    {
        static HtmlParser parser;

        static string searchUrl = "https://www.luxuryhomemarketing.com/real-estate-agents/advanced_search.html";

        private string _response;

        // Загрузка страницы поиска по стране
        public string GetPageWithCountryResults(Country country)
        {
            _response = "";
            try
            {
                var request = new HttpRequest();
                var reqParams = new RequestParams();
                reqParams["Country"] = country.Abbreviation;

                _response = request.Post(searchUrl, reqParams).ToString();

            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            return _response;
        }

        public string ParsePageWithCountry(Country country);

        // Загрузка страницы поиска по штату
        public string GetPageWithStateResults(Country country, State state)
        {
            _response = "";
            try
            {
                var request = new HttpRequest();

                var reqParams = new RequestParams();
                reqParams["Country"] = country;
                reqParams["State_prov"] = state;
                _response = request.Post(searchUrl, reqParams).ToString();

            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            return _response;
        }

        public string ParsePageWithState(State state);

        // Загрузка страницы по уровню членства
        public string GetPageWithMembershipResults(Country country, State state, string memberLevel)
        {
            _response = "";
            try
            {
                //string designation = "";
                //switch (memberLevel)
                //{
                //    case MemberLevel.mlMember:
                //        designation = "M";
                //        break;
                //    case MemberLevel.mlCLHMS:
                //        designation = "C";
                //        break;
                //    case MemberLevel.mlGuild:
                //        designation = "G";
                //        break;
                //    case MemberLevel.mlAffiliate:
                //        designation = "A";
                //        break;
                //}

                HttpRequest request = new HttpRequest();

                var reqParams = new RequestParams();
                reqParams["Country"] = country;
                reqParams["State_prov"] = state;
                reqParams["designation[]"] = memberLevel;

                _response = request.Post(searchUrl, reqParams).ToString();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            return _response;
        }

        public string ParsePageMembership(MemberLevel memberLevel);

        private static void ShowError(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Exception: {ex.InnerException}");
            // Console.WriteLine($"Stack: {ex.StackTrace}");
        }

        Collection<Member> ParsePage(string response)
        {
            Collection<Member> members = new Collection<Member>();
            
            var doc = parser.ParseDocument(response);

            var cells = doc.QuerySelectorAll("div.row.member");
            foreach (var cell in cells)
            { 
                var linkMember = cell.QuerySelector("a.link-member");

                string url = linkMember.GetAttribute("href");
                string memberId = url.Replace("../members/member_", "");
                memberId = memberId.Replace(".html", "");

                members.Add(new Member(memberId));
            }

            // Возвращаем количество найденных пользователей
            return members;
        }

        public bool ParseToManyResultError(string response)
        {
            var doc = parser.ParseDocument(response);

            var cells = doc.QuerySelectorAll("div.row.member");
            // Если поисковый запрос слишком широкий
            // Sorry that search is too broad. Please be more specific.
            cells = doc.QuerySelectorAll("p");
            foreach (var cell in cells)
            {
                if (cell.InnerHtml == "Sorry that search is too broad. Please be more specific.") return true;
            }

            return false;
        }
    }
}
