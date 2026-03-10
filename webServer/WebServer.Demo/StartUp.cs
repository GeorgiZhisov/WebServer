
using System.Text;
using System.Web;
using WebServer.Server;
using WebServer.Server.HTTP;
using WebServer.Server.HTTP_Request;
using WebServer.Server.Responses;
using WebServer.Server.Views;

namespace WebServer.demo
{
    public class StartUp
    {
        private const string Username = "user";
        private const string Password = "user123";
        public static async Task Main()
        {
            await DownloadWebAsTextFile(Form.FileName,
                new string[] { "https://judge.softuni.org/", "https://softuni.org/" });
            var server = new HttpServer(routes =>
            {
                routes
                .MapGet("/", new TextResponse("Hello from the server!"))
                .MapGet("/HTML", new HtmlResponse("<h1>HTML response</h1>"))
                .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
                .MapGet("/TestNameAge", new HtmlResponse(Form.HTML))
                .MapPost("/TestNameAge", new TextResponse("", AddFormDataAction))
                .MapGet("/Content", new HtmlResponse(Form.DownloadForm))
                .MapPost("/Content", new TextFileResponse(Form.FileName))
                .MapGet("/Cookies", new HtmlResponse("", AddCookiesAction))
                .MapGet("/Session", new TextResponse("", DisplaySessionInfoAction))
                .MapGet("/Login", new HtmlResponse(LoginPage.LoginForm))
                .MapPost("/Login", new HtmlResponse("", LoginAction))
                .MapGet("/Logout", new HtmlResponse("", LogoutAction))
                .MapGet("/UserProfile", new HtmlResponse("", GetUserDataAction));
            });
            await server.Start();
        }

        private static void AddFormDataAction(
            Request request, Response response)
        {
            response.Body = "";

            foreach(var (key, value) in request.FromData)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }
        private static async Task<string> DownloadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);
                var html = await response.Content.ReadAsStringAsync();
                return html.Substring(0,2000);
            }
        }
        private static async Task DownloadWebAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }
            var responses = await Task.WhenAll(downloads);

            var responsesString = string.Join(
                Environment.NewLine + new String('-', 100),
                responses);

            await File.WriteAllTextAsync(fileName, responsesString);
        }
        private static void AddCookiesAction(Request request, Response response)
        {
            var requestHasCookies = request.Cookies
                .Any(c => c.Name != Session.SessionCookieName);
            var bodyText = "";
            if (requestHasCookies)
            {
                var cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");
                foreach(var cookie in request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }
                cookieText.Append("</table>");
                bodyText = cookieText.ToString();
            }
            else
            {
                bodyText = "<h1>Cookies set!</h1>";

                response.Cookies.Add("My-Cookie", "My-Value");
                response.Cookies.Add("My-Second-Cookie", "My-Second-Value");
            }
            response.Body = bodyText;
        }
        private static void DisplaySessionInfoAction(Request request, Response response)
        {
            var sessionExists = request.Session
                .ContainsKey(Session.SessionCurrentDateKey);
            var bodyText = "";
            if (sessionExists)
            {
                var currentDate = request.Session[Session.SessionCurrentDateKey];
                bodyText = $"Stored data: {currentDate}!";
            }
            else
            {
                bodyText = "Current date stored!";
            }
            response.Body = "";
            response.Body += bodyText;
        }

        private static void LoginAction(Request request, Response response)
        {
            request.Session.Clear();

            var bodyText = "";

            var usernameMatches = request.FromData["Username"] == Username;
            var passworMatches = request.FromData["Password"] == Password;      

            if (usernameMatches && passworMatches)
            {
                request.Session[Session.SessionUserKey] = "MyUserId";
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

                bodyText = "<h3>Logged successfully! </h3>";
            }
            else
            {
                bodyText = LoginPage.LoginForm;
            }
            response.Body = "";
            response.Body += bodyText;
        }
        private static void LogoutAction(Request request, Response response)
        {
            request.Session.Clear();

            response.Body = "";
            response.Body += "<h3>Logged out successfully!</h3>";
        }
        private static void GetUserDataAction(Request request, Response response)
        {
            if (request.Session.ContainsKey(Session.SessionUserKey))
            {
                response.Body = "";
                response.Body += $"<h3>Currently logged-in user " +
                    $"is with username '{Username}'</h3>";
            }
            else
            {
                response.Body = "";
                response.Body += "<h3>You should first log in" +
                    "- <a href='/Login'>Login</a></h3>";
            }
        }
    }
}