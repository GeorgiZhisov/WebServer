using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuditelWebServer.Server.HTTP
{
	public class Response
	{
        public Response(StatusCode statusCode)
        {
			StatusCode = statusCode;
			Headers.Add(Header.Server,"MyWebServer");
			Headers.Add(Header.Date,$"{DateTime.UtcNow : r}");
		}

		public HeaderCollection Headers { get; } = new HeaderCollection();

        public StatusCode StatusCode { get; init; }
        public string Body { get; set; }

		public Action<Request,Response> PreRnderAction { get; protected set; }




		public override string ToString()
		{
			var result = new StringBuilder();

			result.AppendLine($"HTTP/1.1 {(int)StatusCode} {StatusCode}");
			foreach (var header in Headers)
			{
				result.AppendLine(header.ToString());
			}
			result.AppendLine();

			if (string.IsNullOrWhiteSpace(Body) == false)
			{
				result.Append(Body);
			}
			return result.ToString();
		}

    }
}
