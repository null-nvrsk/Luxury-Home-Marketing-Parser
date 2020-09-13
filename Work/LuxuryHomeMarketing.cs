using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.xNet;
using AngleSharp.Html;
using AngleSharp.Html.Parser;
using AngleSharp;
using AngleSharp.Dom;
using System.Reflection.Emit;
using System.Drawing;
using System.Windows.Forms;

namespace LuxuryHomeMarketing
{
    class LuxuryHomeMarketing
    {
        //public static List<Member> members = new List<Member>();
        public static Members members = new Members();
        public static QueueRequest queue = new QueueRequest();

        public static Countries countries = new Countries();
        public static States states = new States();

        public static string searchUrl = "https://www.luxuryhomemarketing.com/real-estate-agents/advanced_search.html";

        public static int usersTotal = 0;
        public static int usersParsed = 0;

        //---------------------------------------------------------------------
        public static string GetMemberPage(string user)
        {
            string response = "";
            string url = $"https://www.luxuryhomemarketing.com/members/member_{user}.html";

            HttpRequest request = CreateHttpRequest();

            try
            {
                response = request.Get(url).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection error: {ex.Message}");
            }            
            
            return response;
        }


        //---------------------------------------------------------------------
        public static string ParseMember(string response, string memberId)
        {
            var parser = new HtmlParser();
            var doc = parser.ParseDocument(response);

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
                return $"{memberId} - {memberName} - {email}";
            }
            catch (Exception)
            {
            }

            return "";            
        }

        //---------------------------------------------------------------------
        // Обработка поиска по стране
        public static string GetSearchResult(string country)
        {
            string response = "";
            try
            {
                HttpRequest request = CreateHttpRequest();

                var reqParams = new RequestParams();
                reqParams["Country"] = country;

                response = request.Post(searchUrl, reqParams).ToString();

            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
                      
            return response;
        }

        //---------------------------------------------------------------------
        // Обработка поиска по штату
        public static string GetSearchResult(string country, string state)
        {
            string response = "";
            try
            {
                HttpRequest request = CreateHttpRequest(); 

                var reqParams = new RequestParams();
                reqParams["Country"] = country;
                reqParams["State_prov"] = state;
                response = request.Post(searchUrl, reqParams).ToString();

            }
            catch (Exception ex)
            {
                ShowError(ex);                
            }

            return response;
        }        
        
        //---------------------------------------------------------------------
        // Обработка поиска по уровню членства
        public static string GetSearchResult(string country, string state, MemberLevel level)
        {
            string response = "";
            try
            {
                string designation = "";
                switch (level)
                {
                    case MemberLevel.mlMember:
                        designation = "M";
                        break;
                    case MemberLevel.mlCLHMS:
                        designation = "C";
                        break;
                    case MemberLevel.mlGuild:
                        designation = "G";
                        break;
                    case MemberLevel.mlAffiliate:
                        designation = "A";
                        break;
                }

                HttpRequest request = CreateHttpRequest();

                var reqParams = new RequestParams();
                reqParams["Country"] = country;
                reqParams["State_prov"] = state;
                reqParams["designation[]"] = designation;


                response = request.Post(searchUrl, reqParams).ToString();

            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            return response;
        }

        //---------------------------------------------------------------------
        public static int ParseSearchResult(string response, RequestType type)
        {
            int count = 0;
            var parser = new HtmlParser();
            var doc = parser.ParseDocument(response);
   
            // var cells = doc.QuerySelectorAll("p.row.link-list.text-center");
            var cells = doc.QuerySelectorAll("div.row.member");
            foreach (var cell in cells)
            {
                var linkMember = cell.QuerySelector("a.link-member");

                string url = linkMember.GetAttribute("href");
                string memberId = url.Replace("../members/member_", "");
                memberId = memberId.Replace(".html", "");

                // Добавляем в очередь страницы найденых ползоваетелей
                RequestOption requestOption = new RequestOption(memberId, RequestType.rtMember);
                queue.Enqueue(requestOption);
                count++;
            }

            // Если поисковый запрос слишком широкий, бозвращаем -1
            // Sorry that search is too broad. Please be more specific.
            cells = doc.QuerySelectorAll("p");
            foreach (var cell in cells)
            {
                if (cell.InnerHtml == "Sorry that search is too broad. Please be more specific.")
                {
                    if (type == RequestType.rtMemberLevel)
                    {
                        MessageBox.Show("слишком широкий запрос даже на самом нижнем уровне.\n" +
                            "Не все пользователи будут отработаны!");
                    }
                    return -1;
                }   
            }

            // Возвращаем количество найденных пользователей
            return count;
        }

        //---------------------------------------------------------------------
        // Единожды запускаем процесс обработки очереди
        public static void StartQueueProcessing()
        {
            // 1 - Добавляем в очередь запросы по странам
            AddCountriesToQueue();

            usersTotal = 0;
            usersParsed = 0;
            int newUsers; 
            // 2-6 - Обрабатываем очередь до опустошения
            while (queue.Count > 0)
            {
                RequestOption requestOption = queue.Peek();
                string response = "";

                switch (requestOption.type)
                {
                    case RequestType.rtCountry:
                        response = GetSearchResult(requestOption.country);
                        newUsers = ParseSearchResult(response, RequestType.rtCountry);

                        // 
                        if (newUsers >= 0)
                            LogAddNewUsers(newUsers, requestOption);
                        else

                        // Если запрос вернул что найдено слишком много членов, то в очередь запросов
                        // для "US/CA" добавляем со штатами, для остальных стран - по Member Level
                        // 
                        if (newUsers == -1)

                            if (requestOption.country == "US/CA")
                                AddStatesToQueue(requestOption.country);
                            else
                                AddMemberLevelsToQueue(requestOption.country, requestOption.state);

                                break;
                    case RequestType.rtState:
                        response = GetSearchResult(requestOption.country, requestOption.state);
                        newUsers = ParseSearchResult(response, RequestType.rtState);
                        
                        if (newUsers >= 0)
                            LogAddNewUsers(newUsers, requestOption);
                        else
                            AddMemberLevelsToQueue(requestOption.country, requestOption.state);
                        
                        break;
                    case RequestType.rtMemberLevel:
                        response = GetSearchResult(requestOption.country, requestOption.state, requestOption.level);
                        newUsers = ParseSearchResult(response, RequestType.rtMemberLevel);
                        LogAddNewUsers(newUsers, requestOption);

                        if (newUsers >= 0)
                            LogAddNewUsers(newUsers, requestOption);
                        else
                            Console.WriteLine($"[{requestOption.country}/{requestOption.state}/{requestOption.level}] Error: to many users");

                        break;
                    case RequestType.rtMember:
                        response = GetMemberPage(requestOption.memberId);
                        string memberInfo =  ParseMember(response, requestOption.memberId);
                        usersParsed++;

                        LogParseUser(memberInfo, requestOption);
                        
                        break;
                    default:
                        break;
                }

                queue.Dequeue();
            }
        }

        

        //---------------------------------------------------------------------
        // В начале процесса добавляем в очередь все страны
        private static void AddCountriesToQueue()
        {
            foreach (string country in countries)
            {
                RequestOption requestOption = new RequestOption(country);
                queue.Enqueue(requestOption);
            }
        }

        //---------------------------------------------------------------------
        // В процессе добавляем в очередь все штаты
        private static void AddStatesToQueue(string country)
        {
            foreach (string state in states)
            {
                RequestOption requestOption = new RequestOption(country, state);
                queue.Enqueue(requestOption);
            }
        }

        //---------------------------------------------------------------------
        private static void AddMemberLevelsToQueue(string country, string state)
        {
            foreach (MemberLevel level in Enum.GetValues(typeof(MemberLevel)))
            {
                RequestOption requestOption = new RequestOption(country, state, level);
                queue.Enqueue(requestOption);
            }
        }

        //---------------------------------------------------------------------
        private static void LogAddNewUsers(int newUsers, RequestOption requestOption)
        {
          
            usersTotal += newUsers;
            Console.WriteLine($"{usersParsed}/{usersTotal}: [{requestOption.country}/{requestOption.state}] add {newUsers} users");

        }
        //---------------------------------------------------------------------
        private static void LogParseUser(string memberInfo, RequestOption requestOption)
        {
            Console.WriteLine($"{usersParsed}/{usersTotal} [{requestOption.country}/{requestOption.state}] {memberInfo}");
        }

        //---------------------------------------------------------------------
        private static void ShowError(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Exception: {ex.InnerException}");
            // Console.WriteLine($"Stack: {ex.StackTrace}");
        }

        //---------------------------------------------------------------------
        // создаем объект запроса с необходимыми параметрами
        private static HttpRequest CreateHttpRequest()
        {
            HttpRequest request = new HttpRequest();

            request.UseCookies = true;
            request.KeepAlive = true;
            request.AcceptEncoding = "gzip, deflate";
            request.KeepAliveTimeout = 120_000;
            request.UserAgent = Http.ChromeUserAgent();

            return request;
        }
    }
}
