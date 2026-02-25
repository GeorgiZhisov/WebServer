using BuditelWebServer.Server.Common;
using System.Text;

namespace BuditelWebServer.Server.HTTP
{
	public class ContentResponse : Response
	{
		public ContentResponse(string content,string contentType,
			Action<Request,Response> preRenderAction = null) 
			: base(StatusCode.OK)
		{
			Guard.AgainstNull(content);
			Guard.AgainstNull(contentType);

			Headers.Add(Header.ContentType, contentType);
			PreRnderAction = preRenderAction;
			Body = content;
		}

		public override string ToString()
		{
			var contentLength = Encoding.UTF8.GetByteCount(Body);
			this.Headers.Add(Header.ContentLength, contentLength.ToString());

			return base.ToString();
		}
	}
}
