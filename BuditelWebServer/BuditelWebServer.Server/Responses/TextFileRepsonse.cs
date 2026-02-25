using BuditelWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuditelWebServer.Server.Responses
{
	public class TextFileRepsonse : Response
	{
		public TextFileRepsonse(string filename)
			:base(StatusCode.OK)
		{
			Filename = filename;
			Headers.Add(Header.ContentType,ContentType.PlainText);
		}

		public string Filename { get; init; }


		public override string ToString()
		{

			if (File.Exists(Filename))
			{
				Body = File.ReadAllText(Filename);
				var byteCount = new FileInfo(Filename).Length;
				Headers.Add(Header.ContentDisposition, $"attachment; filename=\"{Filename}\"");
				Headers.Add(Header.ContentLength, byteCount.ToString());
			}
			return base.ToString();
		}
	}
}
