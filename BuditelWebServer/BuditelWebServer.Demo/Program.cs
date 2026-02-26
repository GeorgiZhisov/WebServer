using BuditelWebServer.Server;
using BuditelWebServer.Server.HTTP;
using BuditelWebServer.Server.Responses;
using BuditelWebServer.Server.Views;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BuditelWebServer.Demo
{
	internal class Program
	{
		private static string Filename = "content.txt";
		static async Task Main(string[] args)
		{
			await DownloadSitesAsTextFile(Filename,new string[] {"https://www.aboutyou.com","https://www.facebook.com","https://www.youtube.com"});

			var server = new HttpServer(routes =>
			routes.MapGet("/", new HtmlResponse("<form method='post' action='/HTML'><input name='data'/><button type='submit'>Submit</button></form>"))
			.MapGet("/redirect", new RedirectResponse("https://www.aboutyou.com"))
			.MapPost("/HTML", new TextResponse("", AddFormDataAction))
			.MapGet("/content", new HtmlResponse("<form method='post' action='/content'><button type='submit'>Download Content</button></form>"))
			.MapGet("/cookies", new HtmlResponse("<form method='post' action='/cookies'><button type='submit'>Show Cookies</button></form>"))
            .MapPost("/content", new TextFileRepsonse(Filename))
			);
			await server.Start();
		}

		private static void AddFormDataAction(Request request, Response response)
		{
			response.Body = "";

			foreach (var (key,value) in request.FormData)
			{
				response.Body += $"{key} - {value}";
				response.Body += Environment.NewLine;
			}
		}

		


		private static async Task<string> DownloadWebSiteContent(string url)
		{
			var client = new HttpClient();

			using (client)
			{
				var response = await client.GetAsync(url);
				var html = await response.Content.ReadAsStringAsync();
				return html;

			}

		}

		private static async Task DownloadSitesAsTextFile(string filename, string[] urls)
		{
			var downloads = new List<Task<string>>();

			foreach (var url in urls)
			{
				downloads.Add(DownloadWebSiteContent(url));
			}

			var responses = await Task.WhenAll(downloads);

			var responsesString = string.Join($"{Environment.NewLine}{new string('-',100)}",responses);

			await File.WriteAllTextAsync(filename, responsesString);
		}

		private static void AddCookiesAction(Request request, Response response)
		{
			
			if (request.Cookies.Any())
			{
				
				var cookieText = new StringBuilder();
				cookieText.AppendLine("<h1>Cookies:</h1>");

				cookieText
	.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

				foreach (var cookie in request.Cookies)
				{
					cookieText.Append("<tr>");
					cookieText
						.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
					cookieText
						.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
					cookieText.Append("</tr>");
				}

				cookieText.Append("</table>");

				response.Body = cookieText.ToString();
			}
			else
			{
				response.Body = "<h1>Cookies set!</h1>";
			}
		}
	}
}