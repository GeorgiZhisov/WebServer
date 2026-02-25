using BuditelWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuditelWebServer.Server.Responses
{
	internal class UnauthorizedResponse : Response
	{
		public UnauthorizedResponse()
			: base(StatusCode.Unauthorized)
		{
		}
	}
}
