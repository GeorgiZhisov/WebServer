using BuditelWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuditelWebServer.Server.Responses
{
	public class RedirectResponse : Response
	{
		public RedirectResponse(string location) 
			: base(StatusCode.Found)
		{
			Headers.Add(Header.Location, location);
		}
	}
}
