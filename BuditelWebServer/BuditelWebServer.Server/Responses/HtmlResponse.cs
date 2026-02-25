using BuditelWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuditelWebServer.Server.Responses
{
	public class HtmlResponse : ContentResponse
	{
		public HtmlResponse(string html) 
			: base(html,ContentType.Html)
		{
		}
	}
}
